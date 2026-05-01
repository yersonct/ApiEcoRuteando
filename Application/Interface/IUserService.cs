using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IUserService
    {
        Task CreateUser(UserCreateDto dto);
        Task<List<UserResponseDto>> GetAll();
        Task<UserResponseDto?> GetById(int id);
    }
}