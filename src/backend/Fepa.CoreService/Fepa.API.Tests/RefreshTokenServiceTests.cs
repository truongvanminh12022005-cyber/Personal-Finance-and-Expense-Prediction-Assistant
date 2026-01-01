using Xunit;
using Moq;
using Fepa.Application.Services;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Fepa.API.Tests
{
    /*
    public class RefreshTokenServiceTests
    {
        private readonly Mock<IRefreshTokenRepository> _mockRefreshTokenRepository;
        private readonly Mock<ITokenService> _mockTokenService;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly RefreshTokenService _refreshTokenService;

        public RefreshTokenServiceTests()
        {
            _mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            _mockTokenService = new Mock<ITokenService>();
            _mockUserRepository = new Mock<IUserRepository>();
        }

        // [Fact]
        // public async Task RefreshAccessTokenAsync_WithValidToken_ShouldReturnNewToken()
        // {
        //     var userId = Guid.NewGuid();
        //     var user = new User { Id = userId, IsActive = true };
        //     var token = new RefreshToken { UserId = userId, Token = "valid", ExpiresAt = DateTime.UtcNow.AddDays(7) };
        //     _mockRefreshTokenRepository.Setup(r => r.GetByTokenAsync("valid")).ReturnsAsync(token);
        //     _mockUserRepository.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
        //     var result = await _refreshTokenService.RefreshAccessTokenAsync("valid");
        //     Assert.NotNull(result);
        // }

        // [Fact]
        // public async Task RevokeTokenAsync_ShouldMarkAsRevoked()
        // {
        //     var token = new RefreshToken { Id = Guid.NewGuid(), Token = "to_revoke" };
        //     _mockRefreshTokenRepository.Setup(r => r.GetByTokenAsync("to_revoke")).ReturnsAsync(token);
        //     await _refreshTokenService.RevokeTokenAsync("to_revoke");
        //     _mockRefreshTokenRepository.Verify(r => r.RevokeAsync(token.Id), Times.Once);
        // }
    }
    */
}
