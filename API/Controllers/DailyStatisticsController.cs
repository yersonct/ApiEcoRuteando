using Api.Application.DTO.InputDTO;
using Api.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyStatisticsController : ControllerBase
    {
        private readonly DailyStatisticsService _service;

        public DailyStatisticsController(DailyStatisticsService service)
        {
            _service = service;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GetByDateAsync([FromBody] DailyStatisticsCreateDto dto)
        {
            await _service.GetByDateAsync(dto.Date);
            return Ok("Statistics generated");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var result = await _service.GetByDate(date);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
