using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface ITravelHistoryService
    {
        Task RegisterTrip(TravelHistoryCreateDto dto);
        Task<List<TravelHistoryResponseDto>> GetAll();
    }
}