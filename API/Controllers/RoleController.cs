using Api.Application.Interface; 
using Api.Application.DTO.InputDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService; 

        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleCreateDto dto)
        {
            try
            {
                await _roleService.CreateRole(dto);
                return Ok(new { mensaje = "Rol creado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }
    }
}