using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Fepa.Application.Interfaces;
using Fepa.Application.DTOs.Auth;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace Fepa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _authService.RegisterAsync(request);
                return Ok(new { message = "Registration successful. Please verify your email." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration error");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var result = await _authService.LoginAsync(request);
                if (result.RequiresTwoFactor)
                {
                    return Ok(new { requiresTwoFactor = true, message = "Please provide 2FA code" });
                }
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("setup-2fa")]
        [Authorize]
        public async Task<IActionResult> SetupTwoFactor()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            var result = await _authService.SetupTwoFactorAsync(userId);
            return Ok(result);
        }

        [HttpPost("verify-2fa")]
        [Authorize]
        public async Task<IActionResult> VerifyTwoFactor([FromBody] VerifyTwoFactorRequest request)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            await _authService.VerifyAndEnableTwoFactorAsync(userId, request.Code);
            return Ok(new { message = "2FA enabled successfully" });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] EmailVerificationRequest request)
        {
            await _authService.ForgotPasswordAsync(request.Email);
            return Ok(new { message = "Password reset email sent" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetConfirmRequest request)
        {
            // Sửa lỗi: Truyền cả object request vào service
            await _authService.ResetPasswordAsync(request);
            return Ok(new { message = "Password reset successful" });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            // Sửa lỗi: Truyền cả object request vào service (không truyền mỗi string)
            var result = await _authService.RefreshTokenAsync(request);
            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest request)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            
            // Hàm này cần 2 tham số: UserId và RefreshToken (dạng chuỗi)
            await _authService.RevokeTokenAsync(userId, request.RefreshToken);
            return Ok(new { message = "Logout successful" });
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] OAuthLoginRequest request)
        {
            var result = await _authService.GoogleLoginAsync(request);
            return Ok(result);
        }

        [HttpPost("facebook-login")]
        public async Task<IActionResult> FacebookLogin([FromBody] OAuthLoginRequest request)
        {
            var result = await _authService.FacebookLoginAsync(request);
            return Ok(result);
        }
    }
}