using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IRolePermissionService
    {
        Task AssignPermission(RolePermissionCreateDto dto);
        Task<List<RolePermissionResponseDto>> GetAll();
    }
}