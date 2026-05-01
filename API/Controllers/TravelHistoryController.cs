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
    public class TravelHistoryController : ControllerBase
    {
        private readonly ITravelHistoryService _service; 

        public TravelHistoryController(ITravelHistoryService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TravelHistoryResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(TravelHistoryCreateDto dto)
        {
            await _service.RegisterTrip(dto);
            return Ok(new { message = "Travel registered successfully" });
        }
    }
}