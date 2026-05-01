using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IObstacleReportService
    {
        Task CreateReport(ObstacleReportCreateDto dto);
        Task<List<ObstacleReportResponseDto>> GetAll();
    }
}