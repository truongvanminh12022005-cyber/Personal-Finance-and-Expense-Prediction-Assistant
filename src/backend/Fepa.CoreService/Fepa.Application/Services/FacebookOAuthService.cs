using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Fepa.Application.Services
{
    /*
    public class FacebookOAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<FacebookOAuthService> _logger;

        public FacebookOAuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            ILogger<FacebookOAuthService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        // public async Task<LoginResponse> LoginAsync(OAuthLoginRequest request)
        // {
        //     try
        //     {
        //         // Verify Facebook token
        //         var facebookAppId = _configuration["OAuth:Facebook:AppId"];
        //         var facebookAppSecret = _configuration["OAuth:Facebook:AppSecret"];
        //         var httpClient = _httpClientFactory.CreateClient();

        //         // Get user info from Facebook
        //         var response = await httpClient.GetAsync($"https://graph.facebook.com/me?access_token={request.IdToken}&fields=id,name,email");
        //         if (!response.IsSuccessStatusCode)
        //         {
        //             throw new UnauthorizedAccessException("Facebook token không hợp lệ");
        //         }

        //         var facebookUser = await response.Content.ReadAsAsync<dynamic>();
        //         string facebookId = facebookUser["id"];
        //         string email = facebookUser["email"];
        //         string name = facebookUser["name"];

        //         // Check if user exists
        //         var user = await _userRepository.GetByEmailAsync(email);
        //         if (user == null)
        //         {
        //             // Create new user
        //             user = new User
        //             {
        //                 Email = email,
        //                 FullName = name,
        //                 FacebookId = facebookId,
        //                 IsEmailVerified = true,
        //                 IsActive = true,
        //                 CreatedAt = DateTime.UtcNow
        //             };

        //             user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString());
        //             await _userRepository.AddAsync(user);
        //         }
        //         else
        //         {
        //             // Update Facebook ID if not set
        //             if (string.IsNullOrWhiteSpace(user.FacebookId))
        //             {
        //                 user.FacebookId = facebookId;
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
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Facebook OAuth error");
        //         throw new UnauthorizedAccessException("Facebook OAuth thất bại");
        //     }
        // }
    }
    */
}
