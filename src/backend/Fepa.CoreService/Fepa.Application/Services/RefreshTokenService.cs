using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Fepa.Application.Services
{
    /*
    public class RefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RefreshTokenService> _logger;

        public RefreshTokenService(
            IRefreshTokenRepository refreshTokenRepository,
            ITokenService tokenService,
            IUserRepository userRepository,
            ILogger<RefreshTokenService> logger)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _logger = logger;
        }

        // public async Task<LoginResponse> RefreshAccessTokenAsync(string refreshToken)
        // {
        //     var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
        //     if (token == null || !token.IsValid)
        //         throw new UnauthorizedAccessException("Refresh token không hợp lệ");

        //     var user = await _userRepository.GetByIdAsync(token.UserId);
        //     if (user == null || !user.IsActive)
        //         throw new InvalidOperationException("Người dùng không tồn tại");

        //     var newAccessToken = _tokenService.GenerateAccessToken(user);
        //     var newRefreshToken = _tokenService.GenerateRefreshToken();

        //     await _refreshTokenRepository.RevokeAsync(token.Id);
        //     var newTokenEntity = new RefreshToken
        //     {
        //         UserId = user.Id,
        //         Token = newRefreshToken,
        //         ExpiresAt = DateTime.UtcNow.AddDays(7)
        //     };
        //     await _refreshTokenRepository.AddAsync(newTokenEntity);

        //     return new LoginResponse
        //     {
        //         AccessToken = newAccessToken,
        //         RefreshToken = newRefreshToken,
        //         ExpiresIn = 3600,
        //         User = UserDto.FromEntity(user)
        //     };
        // }

        // public async Task RevokeTokenAsync(string refreshToken)
        // {
        //     var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
        //     if (token != null)
        //         await _refreshTokenRepository.RevokeAsync(token.Id);
        // }

        // public async Task RevokeAllUserTokensAsync(Guid userId)
        // {
        //     await _refreshTokenRepository.RevokeAllByUserIdAsync(userId);
        //     _logger.LogInformation($"All tokens revoked for user {userId}");
        // }
    }
    */
}
