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
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _service; 

        public UserRoleController(IUserRoleService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRoleResponseDto>>> Get()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRoleCreateDto dto)
        {
            await _service.AssignRole(dto);
            return Ok(new { mensaje = "Role asignado al usuario correctamente" });
        }
    }
}