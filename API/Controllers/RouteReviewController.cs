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
    public class RouteReviewController : ControllerBase
    {
        private readonly IRouteReviewService _service; 

        public RouteReviewController(IRouteReviewService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RouteReviewResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(RouteReviewCreateDto dto)
        {
            await _service.CreateReview(dto);
            return Ok(new { mensaje = "Reseña publicada con éxito" });
        }
    }
}