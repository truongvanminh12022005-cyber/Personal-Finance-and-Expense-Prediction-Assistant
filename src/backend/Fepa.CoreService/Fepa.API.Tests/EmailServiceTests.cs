using Xunit;
using Moq;
using Fepa.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fepa.API.Tests
{
    /*
    public class EmailServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<ILogger<EmailService>> _mockLogger;
        private readonly EmailService _emailService;

        public EmailServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger<EmailService>>();
            _mockConfiguration.Setup(c => c["Email:SmtpServer"]).Returns("smtp.gmail.com");
            _mockConfiguration.Setup(c => c["Email:SmtpPort"]).Returns("587");
        }

        // [Fact]
        // public async Task SendEmailVerificationAsync_WithValidData_ShouldSucceed()
        // {
        //     var email = "user@example.com";
        //     var link = "https://app.com/verify?token=abc";
        //     await _emailService.SendEmailVerificationAsync(email, link, "John");
        // }

        // [Fact]
        // public async Task SendPasswordResetEmailAsync_WithValidData_ShouldSucceed()
        // {
        //     var email = "user@example.com";
        //     var link = "https://app.com/reset?token=xyz";
        //     await _emailService.SendPasswordResetEmailAsync(email, link, "John");
        // }
    }
    */
}
