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
    public class PointOfInterestController : ControllerBase
    {
        private readonly IPointOfInterestService _service; 

        public PointOfInterestController(IPointOfInterestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PointOfInterestResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(PointOfInterestCreateDto dto)
        {
            await _service.CreatePointOfInterest(dto);
            // Mantenemos el mensaje de confirmación en español
            return Ok(new { mensaje = "Punto de interés creado correctamente" });
        }
    }
}