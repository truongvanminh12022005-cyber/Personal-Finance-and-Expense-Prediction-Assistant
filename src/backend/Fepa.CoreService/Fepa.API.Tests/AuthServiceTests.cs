using Xunit;
using Moq;
using Fepa.Application.Services;
using Fepa.Application.Interfaces;
using Fepa.Application.DTOs.Auth;
using Fepa.Domain.Entities;

namespace Fepa.API.Tests
{
    /*
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEmailService = new Mock<IEmailService>();
        }

        // [Fact]
        // public async Task Register_WithValidData_ShouldSucceed()
        // {
        //     var request = new RegisterRequest { FullName = "John", Email = "john@ex.com", Password = "Pass123!" };
        //     _mockUserRepository.Setup(r => r.GetByEmailAsync(request.Email)).ReturnsAsync((User)null);
        //     _mockUserRepository.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
        //     var result = await _authService.RegisterAsync(request);
        //     Assert.NotNull(result);
        // }

        // [Fact]
        // public async Task Login_WithCorrectPassword_ShouldReturnToken()
        // {
        //     var user = new User { Email = "test@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("CorrectPass123!") };
        //     var request = new LoginRequest { Email = user.Email, Password = "CorrectPass123!" };
        //     _mockUserRepository.Setup(r => r.GetByEmailAsync(request.Email)).ReturnsAsync(user);
        //     var result = await _authService.LoginAsync(request);
        //     Assert.NotNull(result);
        //     Assert.NotEmpty(result.AccessToken);
        // }
    }
    */
}
