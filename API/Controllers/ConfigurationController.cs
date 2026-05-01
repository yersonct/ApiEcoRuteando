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
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _service; 

        public ConfigurationController(IConfigurationService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConfigurationResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(ConfigurationCreateDto dto)
        {
            await _service.CreateConfiguration(dto);
            return Ok(new { mensaje = "Configuración guardada" });
        }
    }
}