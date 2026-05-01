using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IAuditLogService
    {
        Task Register(AuditLogCreateDto dto);
        Task<List<AuditLogResponseDto>> GetAll();
    }
}