using Microsoft.AspNetCore.Mvc;
using Fepa.Application.Interfaces;
using Fepa.Application.DTOs.Auth;

namespace Fepa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // dang ky
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try {
                await _authService.RegisterAsync(request);
                return Ok(new { message = "Đăng ký thành công!" });
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }

        // dang nhap
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try {
                var response = await _authService.LoginAsync(request);
                return Ok(response);
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Quen mat khau
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            try
            {
                await _authService.ForgotPasswordAsync(email);
                return Ok(new { message = "Vui lòng kiểm tra email để lấy lại mật khẩu." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}