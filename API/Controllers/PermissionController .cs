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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService; 

        public PermissionController(IPermissionService permissionService) 
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermissionResponseDto>>> Get()
            => Ok(await _permissionService.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(PermissionCreateDto dto)
        {
            await _permissionService.CreatePermission(dto);
            return Ok(new { mensaje = "Permiso creado" });
        }
    }
}