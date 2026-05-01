using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IPermissionService
    {
        Task CreatePermission(PermissionCreateDto dto);
        Task<List<PermissionResponseDto>> GetAll();
    }
}