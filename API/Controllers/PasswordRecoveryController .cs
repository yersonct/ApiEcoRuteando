using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using Api.Application.Interface; // Usamos la interfaz
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IPasswordRecoveryService _service; 

        public PasswordRecoveryController(IPasswordRecoveryService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PasswordRecoveryResponseDto>>> Get()
            => Ok(await _service.GetAll());

        [HttpPost("request")]
        public async Task<IActionResult> Request(RequestPasswordRecoveryDto dto)
        {
            await _service.RequestRecovery(dto);
            return Ok();
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify(VerifyRecoveryCodeDto dto)
        {
            var result = await _service.VerifyCode(dto);
            return Ok(result);
        }

        [HttpPost("reset")]
        public async Task<IActionResult> Reset(ResetPasswordDto dto)
        {
            await _service.ResetPassword(dto);
            return Ok();
        }
    }
}