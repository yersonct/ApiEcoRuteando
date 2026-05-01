using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.ValueObjects;
using Api.Application.Interface; 
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Service
{
    public class SessionService : ISessionService 
    {
        private readonly ISessionRepository _repository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateSession(SessionCreateDto dto)
        {
            var session = new Session
            {
                UserId = dto.UserId,
                IpAddress = new IpAddress(dto.IpAddress),
                TokenId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };

            await _repository.CreateAsync(session);
        }

        public async Task<List<SessionResponseDto>> GetAll()
        {
            var sessions = await _repository.GetAllAsync();
            return _mapper.Map<List<SessionResponseDto>>(sessions);
        }
    }
}