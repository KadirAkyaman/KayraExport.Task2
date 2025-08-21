using KayraExport.Application.Interfaces;
using KayraExport.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KayraExport.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            var authResult = await _authService.LoginUserAsync(loginUserDto);
            if (authResult == null) return Unauthorized();
            return Ok(authResult);
        }
    }
}
