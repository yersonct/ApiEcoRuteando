using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using Api.Application.Interface; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObstacleReportController : ControllerBase
    {
        private readonly IObstacleReportService _service; 

        public ObstacleReportController(IObstacleReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ObstacleReportResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(ObstacleReportCreateDto dto)
        {
            await _service.CreateReport(dto);
            return Ok(new { mensaje = "Reporte de obstáculo creado exitosamente" });
        }
    }
}