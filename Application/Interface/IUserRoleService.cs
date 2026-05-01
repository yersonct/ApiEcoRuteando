using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IUserRoleService
    {
        Task AssignRole(UserRoleCreateDto dto);
        Task<List<UserRoleResponseDto>> GetAll();
    }
}