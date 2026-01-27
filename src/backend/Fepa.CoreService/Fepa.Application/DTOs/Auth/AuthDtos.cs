using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fepa.Domain.Entities;

namespace Fepa.Application.DTOs.Auth
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public static UserDto FromEntity(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                // Chuyển Role sanh chuỗi
                Role = user.Role.ToString() 
            };
        }
    }


    // 1. Đăng ký
    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    // 2. Đăng nhập
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }

    // 3. Đăng nhập bước 2 (2FA)
    public class TwoFactorLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string TwoFactorCode { get; set; } = string.Empty;
        public bool RememberClient { get; set; }
    }

    // 4. Xác thực 2FA
    public class VerifyTwoFactorRequest
    {
        [Required]
        public string Code { get; set; } = string.Empty;
    }

    // 5. Quên mật khẩu
    public class EmailVerificationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }

    // 6. Reset mật khẩu
    public class PasswordResetConfirmRequest
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = string.Empty;
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    // 7. Refresh Token Request
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }

    // 8. Đổi mật khẩu
    public class ChangePasswordRequest
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = string.Empty;
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    // 9. Đăng nhập Google/Facebook
    public class OAuthLoginRequest
    {
        [Required]
        public string Provider { get; set; } = string.Empty; 
        [Required]
        public string IdToken { get; set; } = string.Empty;
    }

    // Cac ket qua tra ve

    // Kết quả Login
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public bool RequiresTwoFactor { get; set; }
        

        public int ExpiresIn { get; set; } 
        
        public UserDto User { get; set; }
    }

    // Kết quả Refresh Token
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public int ExpiresIn { get; set; } 
    }

    // Kết quả cài đặt 2FA
    public class TwoFactorSetupResponse
    {
        public string QrCodeUrl { get; set; } = string.Empty;
        public string ManualEntryKey { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public List<string> BackupCodes { get; set; } = new List<string>();
    }

    public class AuthResponse : LoginResponse { }
}