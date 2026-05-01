using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IPasswordRecoveryService
    {
        Task<List<PasswordRecoveryResponseDto>> GetAll();
        Task RequestRecovery(RequestPasswordRecoveryDto dto);
        Task<bool> VerifyCode(VerifyRecoveryCodeDto dto);
        Task ResetPassword(ResetPasswordDto dto);
    }
}