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

        #region Basic Authentication

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email không được để trống");
            if (request.Password.Length < 8)
                throw new ArgumentException("Mật khẩu phải ít nhất 8 ký tự");
            if (string.IsNullOrWhiteSpace(request.FullName))
                throw new ArgumentException("Tên không được để trống");

            // Check if email already exists
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Email này đã được sử dụng");

            // Hash password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Create new user
            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "User",
                IsEmailVerified = false,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(newUser);
            
            // Send verification email
            await SendEmailVerificationAsync(request.Email);

            _logger.LogInformation($"User registered: {request.Email}");
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Email hoặc mật khẩu không đúng");

            // FIX: Use BCrypt.Verify instead of comparing hash with plain text
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Email hoặc mật khẩu không đúng");

            if (!user.IsActive)
                throw new UnauthorizedAccessException("Tài khoản đã bị khóa");

            // Check if 2FA is enabled
            if (user.IsTwoFactorEnabled)
            {
                // Return response indicating 2FA is required
                return new LoginResponse
                {
                    RequiresTwoFactor = true,
                    AccessToken = request.Email // Temporary, will be replaced with actual token on 2FA verify
                };
            }

            // Generate tokens
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Update last login
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

        #endregion

        #region Email Verification

        public async Task SendEmailVerificationAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            var token = _tokenService.GenerateVerificationToken();
            var verificationLink = $"https://app.fepa.com/verify-email?email={Uri.EscapeDataString(email)}&token={token}";

            await _emailService.SendEmailVerificationAsync(email, verificationLink, user.FullName);

            _logger.LogInformation($"Verification email sent to {email}");
        }

        public async Task VerifyEmailAsync(string email, string token)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            if (user.IsEmailVerified)
                throw new InvalidOperationException("Email đã được xác minh");

            // In production, validate token against database
            // For now, simple validation
            if (string.IsNullOrWhiteSpace(token))
                throw new InvalidOperationException("Token không hợp lệ");

            user.IsEmailVerified = true;
            user.EmailVerifiedAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation($"Email verified for {email}");
        }

        public async Task ResendVerificationEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            if (user.IsEmailVerified)
                throw new InvalidOperationException("Email đã được xác minh");

            await SendEmailVerificationAsync(email);
        }

        #endregion

        #region Two-Factor Authentication

        public async Task<TwoFactorSetupResponse> SetupTwoFactorAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            var secret = _otpService.GenerateTotpSecret();
            var qrCodeUrl = _otpService.GenerateQrCodeUrl(user.Email, secret);
            var backupCodes = _otpService.GenerateBackupCodes(10);

            // Store secret temporarily (not confirmed yet)
            user.TwoFactorSecret = secret;
            await _userRepository.UpdateAsync(user);

            return new TwoFactorSetupResponse
            {
                Secret = secret,
                QrCodeUrl = qrCodeUrl,
                BackupCodes = backupCodes
            };
        }

        public async Task VerifyAndEnableTwoFactorAsync(Guid userId, string code)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            if (string.IsNullOrWhiteSpace(user.TwoFactorSecret))
                throw new InvalidOperationException("2FA chưa được thiết lập");

            if (!_otpService.VerifyTotpCode(user.TwoFactorSecret, code))
                throw new InvalidOperationException("Mã TOTP không hợp lệ");

            user.IsTwoFactorEnabled = true;
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation($"2FA enabled for user {userId}");
        }

        public async Task DisableTwoFactorAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            user.IsTwoFactorEnabled = false;
            user.TwoFactorSecret = null;
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation($"2FA disabled for user {userId}");
        }

        public async Task<LoginResponse> LoginWithTwoFactorAsync(TwoFactorLoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Email hoặc mật khẩu không đúng");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Email hoặc mật khẩu không đúng");

            if (!user.IsTwoFactorEnabled || string.IsNullOrWhiteSpace(user.TwoFactorSecret))
                throw new InvalidOperationException("2FA không được bật");

            if (!_otpService.VerifyTotpCode(user.TwoFactorSecret, request.TwoFactorCode))
                throw new UnauthorizedAccessException("Mã 2FA không hợp lệ");

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

        #endregion

        #region Password Management

        public async Task ForgotPasswordAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            var token = _tokenService.GenerateVerificationToken();
            var resetLink = $"https://app.fepa.com/reset-password?email={Uri.EscapeDataString(email)}&token={token}";

            await _emailService.SendPasswordResetEmailAsync(email, resetLink, user.FullName);

            _logger.LogInformation($"Password reset email sent to {email}");
        }

        public async Task ResetPasswordAsync(PasswordResetConfirmRequest request)
        {
            if (request.NewPassword != request.ConfirmPassword)
                throw new InvalidOperationException("Mật khẩu không khớp");

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.PasswordHash = passwordHash;
            user.PasswordChangedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation($"Password reset for {request.Email}");
        }

        public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request)
        {
            if (request.NewPassword != request.ConfirmPassword)
                throw new InvalidOperationException("Mật khẩu không khớp");

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new InvalidOperationException("User không tồn tại");

            if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
                throw new UnauthorizedAccessException("Mật khẩu hiện tại không đúng");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.PasswordHash = passwordHash;
            user.PasswordChangedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation($"Password changed for user {userId}");
        }

        #endregion

        #region Token Management

        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            // Validate refresh token (implementation would check against database)
            // For now, simplified implementation

            if (string.IsNullOrWhiteSpace(request.RefreshToken))
                throw new UnauthorizedAccessException("Refresh token không hợp lệ");

            // Generate new tokens
            var newAccessToken = "dummy"; // Would be generated from user
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            return new RefreshTokenResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                ExpiresIn = 3600
            };
        }

        public async Task RevokeTokenAsync(Guid userId, string token)
        {
            // Implementation would revoke token in database
            _logger.LogInformation($"Token revoked for user {userId}");
        }

        #endregion

        #region OAuth (Placeholder)

        public async Task<LoginResponse> GoogleLoginAsync(OAuthLoginRequest request)
        {
            // Implementation would validate IdToken with Google
            throw new NotImplementedException("Google OAuth coming soon");
        }

        public async Task<LoginResponse> FacebookLoginAsync(OAuthLoginRequest request)
        {
            // Implementation would validate IdToken with Facebook
            throw new NotImplementedException("Facebook OAuth coming soon");
        }

        #endregion
    }
}