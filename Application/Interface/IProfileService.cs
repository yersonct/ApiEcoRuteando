using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IProfileService
    {
        Task CreateProfile(ProfileCreateDto dto);
        Task<List<ProfileResponseDto>> GetAll();
    }
}