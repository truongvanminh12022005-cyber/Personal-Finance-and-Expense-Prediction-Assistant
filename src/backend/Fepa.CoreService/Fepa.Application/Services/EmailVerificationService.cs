using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Fepa.Application.Services
{
    /*
    public class EmailVerificationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVerificationTokenRepository _verificationTokenRepository;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<EmailVerificationService> _logger;

        public EmailVerificationService(
            IUserRepository userRepository,
            IVerificationTokenRepository verificationTokenRepository,
            IEmailService emailService,
            ITokenService tokenService,
            ILogger<EmailVerificationService> logger)
        {
            _userRepository = userRepository;
            _verificationTokenRepository = verificationTokenRepository;
            _emailService = emailService;
            _tokenService = tokenService;
            _logger = logger;
        }

        // public async Task SendVerificationEmailAsync(string email)
        // {
        //     var user = await _userRepository.GetByEmailAsync(email);
        //     if (user == null)
        //     {
        //         _logger.LogWarning($"Verification email requested for non-existent email: {email}");
        //         return;  // Security: don't reveal if email exists
        //     }

        //     var verificationToken = _tokenService.GenerateVerificationToken();
        //     var token = new VerificationToken
        //     {
        //         UserId = user.Id,
        //         Token = verificationToken,
        //         Type = "EmailVerification",
        //         ExpiresAt = DateTime.UtcNow.AddHours(24)
        //     };

        //     await _verificationTokenRepository.AddAsync(token);
        //     var verificationLink = $"https://app.fepa.vn/verify-email?token={verificationToken}";
        //     await _emailService.SendEmailVerificationAsync(user.Email, verificationLink, user.FullName);

        //     _logger.LogInformation($"Verification email sent to {email}");
        // }

        // public async Task<bool> VerifyEmailAsync(string email, string token)
        // {
        //     var verificationToken = await _verificationTokenRepository.GetByTokenAsync(token);
        //     if (verificationToken == null || verificationToken.Type != "EmailVerification" || verificationToken.IsExpired)
        //     {
        //         return false;
        //     }

        //     var user = await _userRepository.GetByIdAsync(verificationToken.UserId);
        //     if (user == null || user.Email != email)
        //     {
        //         return false;
        //     }

        //     user.IsEmailVerified = true;
        //     user.EmailVerifiedAt = DateTime.UtcNow;
        //     await _userRepository.UpdateAsync(user);
        //     await _verificationTokenRepository.MarkAsUsedAsync(verificationToken.Id);

        //     _logger.LogInformation($"Email verified for user {user.Id}");
        //     return true;
        // }

        // public async Task ResendVerificationEmailAsync(string email)
        // {
        //     var user = await _userRepository.GetByEmailAsync(email);
        //     if (user == null || user.IsEmailVerified)
        //     {
        //         return;  // Don't reveal status
        //     }

        //     // Invalidate previous tokens
        //     var existingTokens = await _verificationTokenRepository.GetByUserIdAndTypeAsync(user.Id, "EmailVerification");
        //     // Delete or expire existing tokens

        //     await SendVerificationEmailAsync(email);
        // }

        // public async Task<bool> IsEmailVerifiedAsync(Guid userId)
        // {
        //     var user = await _userRepository.GetByIdAsync(userId);
        //     return user?.IsEmailVerified ?? false;
        // }
    }
    */
}
