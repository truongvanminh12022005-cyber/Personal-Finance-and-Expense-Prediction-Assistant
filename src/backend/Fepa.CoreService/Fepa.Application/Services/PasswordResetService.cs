using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Fepa.Application.Services
{
    /*
    public class PasswordResetService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;
        private readonly IVerificationTokenRepository _verificationTokenRepository;
        private readonly ILogger<PasswordResetService> _logger;

        public PasswordResetService(
            IUserRepository userRepository,
            IEmailService emailService,
            ITokenService tokenService,
            IVerificationTokenRepository verificationTokenRepository,
            ILogger<PasswordResetService> logger)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _tokenService = tokenService;
            _verificationTokenRepository = verificationTokenRepository;
            _logger = logger;
        }

        // public async Task ForgotPasswordAsync(string email)
        // {
        //     var user = await _userRepository.GetByEmailAsync(email);
        //     if (user == null)
        //         return;  // Security: don't reveal if user exists

        //     var resetToken = _tokenService.GenerateVerificationToken();
        //     var verificationToken = new VerificationToken
        //     {
        //         UserId = user.Id,
        //         Token = resetToken,
        //         Type = "PasswordReset",
        //         ExpiresAt = DateTime.UtcNow.AddHours(1)
        //     };

        //     await _verificationTokenRepository.AddAsync(verificationToken);
        //     var resetLink = $"https://app.fepa.vn/reset-password?token={resetToken}";
        //     await _emailService.SendPasswordResetEmailAsync(user.Email, resetLink, user.FullName);
        // }

        // public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        // {
        //     var verificationToken = await _verificationTokenRepository.GetByTokenAsync(token);
        //     if (verificationToken == null || verificationToken.Type != "PasswordReset" || verificationToken.IsExpired)
        //         return false;

        //     var user = await _userRepository.GetByIdAsync(verificationToken.UserId);
        //     if (user == null)
        //         return false;

        //     user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        //     user.PasswordChangedAt = DateTime.UtcNow;
        //     await _userRepository.UpdateAsync(user);
        //     await _verificationTokenRepository.MarkAsUsedAsync(verificationToken.Id);

        //     _logger.LogInformation($"Password reset successful for user {user.Id}");
        //     return true;
        // }

        // public async Task<bool> ValidateResetTokenAsync(string token)
        // {
        //     var verificationToken = await _verificationTokenRepository.GetByTokenAsync(token);
        //     return verificationToken != null && verificationToken.Type == "PasswordReset" && verificationToken.IsValid;
        // }
    }
    */
}
