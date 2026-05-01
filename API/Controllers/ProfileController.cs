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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _service; 

        public ProfileController(IProfileService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfileResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(ProfileCreateDto dto)
        {
            await _service.CreateProfile(dto);
            // Mantenemos tu mensaje en español
            return Ok(new { mensaje = "Perfil creado con éxito" });
        }
    }
}