using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface ISessionService
    {
        Task CreateSession(SessionCreateDto dto);
        Task<List<SessionResponseDto>> GetAll();
    }
}
