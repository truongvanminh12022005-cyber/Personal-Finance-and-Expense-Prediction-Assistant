using Xunit;
using Moq;
using Fepa.Application.Services;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Fepa.API.Tests
{
    /*
    public class PasswordResetServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<ILogger<PasswordResetService>> _mockLogger;
        private readonly PasswordResetService _passwordResetService;

        public PasswordResetServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEmailService = new Mock<IEmailService>();
            _mockLogger = new Mock<ILogger<PasswordResetService>>();
        }

        // [Fact]
        // public async Task ForgotPasswordAsync_WithValidEmail_ShouldSendEmail()
        // {
        //     var email = "user@example.com";
        //     var user = new User { Id = Guid.NewGuid(), Email = email };
        //     _mockUserRepository.Setup(r => r.GetByEmailAsync(email)).ReturnsAsync(user);
        //     await _passwordResetService.ForgotPasswordAsync(email);
        //     _mockEmailService.Verify(e => e.SendPasswordResetEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        // }

        // [Fact]
        // public async Task ResetPasswordAsync_WithValidToken_ShouldUpdatePassword()
        // {
        //     var token = new VerificationToken { Type = "PasswordReset", ExpiresAt = DateTime.UtcNow.AddHours(1) };
        //     var user = new User { Id = token.UserId };
        //     var result = await _passwordResetService.ResetPasswordAsync("valid_token", "NewPass123!");
        //     Assert.True(result);
        // }
    }
    */
}
