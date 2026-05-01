using AutoMapper;
using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Application.Interface;
using Api.Domain.ValueObjects; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Service
{
    public class PasswordRecoveryService : IPasswordRecoveryService
    {
        private readonly IPasswordRecoveryRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public PasswordRecoveryService(
            IPasswordRecoveryRepository repository,
            IUserRepository userRepository,
            IEmailService emailService,
            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task RequestRecovery(RequestPasswordRecoveryDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return;

            string code = new Random().Next(100000, 999999).ToString();

            var recovery = new PasswordRecovery
            {
                UserId = user.Id,
                TemporaryCode = new RecoveryCode(code),
                ExpirationDate = new ExpirationDate(DateTime.UtcNow.AddMinutes(15)),
                IsUsed = false
            };

            await _repository.AddAsync(recovery);
            await _repository.SaveChangesAsync();

            string emailBody = $@"
        <div style='font-family: Arial, sans-serif; border: 1px solid #ddd; padding: 20px; max-width: 600px; border-radius: 10px;'>
            <h2 style='color: #2e7d32;'>Hola, {user.Name.Value} {user.LastName}!</h2>
            <p>Has solicitado restablecer tu contraseña para tu cuenta vinculada al correo: <strong>{user.Email.Value}</strong>.</p>
            <div style='background-color: #f1f8e9; padding: 15px; text-align: center; border-radius: 5px; margin: 20px 0;'>
                <span style='font-size: 24px; font-weight: bold; letter-spacing: 5px; color: #1b5e20;'>{code}</span>
            </div>
            <p style='color: #555;'>Este código es válido por <strong>15 minutos</strong>. Si no solicitaste este cambio, puedes ignorar este mensaje de seguridad.</p>
            <hr style='border: 0; border-top: 1px solid #eee; margin: 20px 0;'>
            <p style='font-size: 12px; color: #888;'>Atentamente,<br>Equipo de Soporte EcoRuteando - Neiva, Huila</p>
        </div>";

            await _emailService.SendEmailAsync(
                dto.Email,
                "EcoRuteando - Código de Recuperación",
                emailBody);
        }

        public async Task<bool> VerifyCode(VerifyRecoveryCodeDto dto)
        {
            var recovery = await _repository.GetByEmailAndCode(dto.Email, dto.Code);

            if (recovery == null || recovery.IsUsed || recovery.ExpirationDate.Value < DateTime.UtcNow)
                return false;

            return true;
        }

        public async Task ResetPassword(ResetPasswordDto dto)
        {
            var recovery = await _repository.GetByEmailAndCode(dto.Email, dto.Code);

            if (recovery != null && !recovery.IsUsed && recovery.ExpirationDate.Value >= DateTime.UtcNow)
            {
                var user = await _userRepository.GetByIdAsync(recovery.UserId);
                user.Password = new Password(dto.NewPassword);

                recovery.IsUsed = true;

                await _userRepository.UpdateAsync(user);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<List<PasswordRecoveryResponseDto>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<PasswordRecoveryResponseDto>>(list);
        }
    }
}