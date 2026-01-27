using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Fepa.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IOtpService _otpService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUserRepository userRepository,
            IEmailService emailService,
            IOtpService otpService,
            ITokenService tokenService,
            IConfiguration configuration,
            ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _otpService = otpService;
            _tokenService = tokenService;
            _configuration = configuration;
            _logger = logger;
        }

        // --- ĐĂNG KÝ (ĐÃ SỬA ĐỂ CHẠY NGAY) ---
        public async Task RegisterAsync(RegisterRequest request)
        {
            // 1. Validate
            if (string.IsNullOrWhiteSpace(request.Email)) throw new ArgumentException("Email không được để trống");
            if (request.Password.Length < 6) throw new ArgumentException("Mật khẩu phải ít nhất 6 ký tự");
            if (string.IsNullOrWhiteSpace(request.FullName)) throw new ArgumentException("Tên không được để trống");

            // 2. Check trùng
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null) throw new InvalidOperationException("Email này đã được sử dụng");

            // 3. Hash mật khẩu
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 4. Tạo User
            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "User",
                IsEmailVerified = true,  // <--- QUAN TRỌNG: Đặt là true để đăng nhập được luôn
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(newUser);

            // 5. TẮT GỬI MAIL (Để không bị lỗi server)
            // await SendEmailVerificationAsync(request.Email);

            _logger.LogInformation($"User registered: {request.Email}");
        }

        // --- ĐĂNG NHẬP ---
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) throw new UnauthorizedAccessException("Email hoặc mật khẩu không đúng");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Email hoặc mật khẩu không đúng");

            if (!user.IsActive) throw new UnauthorizedAccessException("Tài khoản đã bị khóa");

            // Bỏ qua check 2FA tạm thời để ưu tiên đăng nhập thường
            // if (user.IsTwoFactorEnabled) { ... }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.LastLoginAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = 3600,
                User = UserDto.FromEntity(user),
                RequiresTwoFactor = false
            };
        }

        // --- CÁC HÀM KHÁC (GIỮ NGUYÊN ĐỂ KHÔNG LỖI CODE) ---
        public async Task SendEmailVerificationAsync(string email) { await Task.CompletedTask; }
        public async Task VerifyEmailAsync(string email, string token) { await Task.CompletedTask; }
        public async Task ResendVerificationEmailAsync(string email) { await Task.CompletedTask; }
        public async Task<TwoFactorSetupResponse> SetupTwoFactorAsync(Guid userId) { throw new NotImplementedException(); }
        public async Task VerifyAndEnableTwoFactorAsync(Guid userId, string code) { await Task.CompletedTask; }
        public async Task DisableTwoFactorAsync(Guid userId) { await Task.CompletedTask; }
        public async Task<LoginResponse> LoginWithTwoFactorAsync(TwoFactorLoginRequest request) { throw new NotImplementedException(); }
        public async Task ForgotPasswordAsync(string email) { await Task.CompletedTask; }
        public async Task ResetPasswordAsync(PasswordResetConfirmRequest request) { await Task.CompletedTask; }
        public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request) { await Task.CompletedTask; }
        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request) { throw new NotImplementedException(); }
        public async Task RevokeTokenAsync(Guid userId, string token) { await Task.CompletedTask; }
        public async Task<LoginResponse> GoogleLoginAsync(OAuthLoginRequest request) { throw new NotImplementedException(); }
        public async Task<LoginResponse> FacebookLoginAsync(OAuthLoginRequest request) { throw new NotImplementedException(); }
    }
}