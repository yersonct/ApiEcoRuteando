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
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _service; 

        public AuditLogController(IAuditLogService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuditLogResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(AuditLogCreateDto dto)
        {
            await _service.Register(dto);
            return Ok(new { mensaje = "Registro de auditoría guardado" });
        }
    }
}