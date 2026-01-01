using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fepa.Application.Services
{
    /*
    public class GoogleOAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GoogleOAuthService> _logger;

        public GoogleOAuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IConfiguration configuration,
            ILogger<GoogleOAuthService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
            _logger = logger;
        }

        // public async Task<LoginResponse> LoginAsync(OAuthLoginRequest request)
        // {
        //     try
        //     {
        //         // Validate Google ID token using Google.Apis.Auth library
        //         var googleClientId = _configuration["OAuth:Google:ClientId"];
        //         var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings { Audience = new[] { googleClientId } });

        //         // Check if user exists
        //         var user = await _userRepository.GetByEmailAsync(payload.Email);
        //         if (user == null)
        //         {
        //             // Create new user from Google info
        //             user = new User
        //             {
        //                 Email = payload.Email,
        //                 FullName = payload.Name,
        //                 GoogleId = payload.Subject,
        //                 IsEmailVerified = payload.EmailVerified,
        //                 IsActive = true,
        //                 CreatedAt = DateTime.UtcNow
        //             };

        //             // Generate temporary password (user won't need it for OAuth)
        //             user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString());
        //             await _userRepository.AddAsync(user);
        //         }
        //         else
        //         {
        //             // Update Google ID if not set
        //             if (string.IsNullOrWhiteSpace(user.GoogleId))
        //             {
        //                 user.GoogleId = payload.Subject;
        //                 user.IsEmailVerified = true;
        //                 await _userRepository.UpdateAsync(user);
        //             }
        //         }

        //         // Generate tokens
        //         var accessToken = _tokenService.GenerateAccessToken(user);
        //         var refreshToken = _tokenService.GenerateRefreshToken();

        //         user.LastLoginAt = DateTime.UtcNow;
        //         await _userRepository.UpdateAsync(user);

        //         return new LoginResponse
        //         {
        //             AccessToken = accessToken,
        //             RefreshToken = refreshToken,
        //             ExpiresIn = 3600,
        //             User = UserDto.FromEntity(user),
        //             RequiresTwoFactor = false
        //         };
        //     }
        //     catch (InvalidOperationException ex)
        //     {
        //         _logger.LogError(ex, "Invalid Google token");
        //         throw new UnauthorizedAccessException("Google token không hợp lệ");
        //     }
        // }
    }
    */
}
