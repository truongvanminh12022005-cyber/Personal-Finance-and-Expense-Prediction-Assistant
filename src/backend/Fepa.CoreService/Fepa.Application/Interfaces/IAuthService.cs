using Fepa.Application.DTOs.Auth;

namespace Fepa.Application.Interfaces
{
    public interface IAuthService
    {
        // Basic Auth
        Task RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);

        // Email Verification
        Task SendEmailVerificationAsync(string email);
        Task VerifyEmailAsync(string email, string token);
        Task ResendVerificationEmailAsync(string email);

        // Two-Factor Authentication
        Task<TwoFactorSetupResponse> SetupTwoFactorAsync(Guid userId);
        Task VerifyAndEnableTwoFactorAsync(Guid userId, string code);
        Task DisableTwoFactorAsync(Guid userId);
        Task<LoginResponse> LoginWithTwoFactorAsync(TwoFactorLoginRequest request);

        // Password Management
        Task ForgotPasswordAsync(string email);
        Task ResetPasswordAsync(PasswordResetConfirmRequest request);
        Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request);

        // Token Management
        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task RevokeTokenAsync(Guid userId, string token);

        // OAuth
        Task<LoginResponse> GoogleLoginAsync(OAuthLoginRequest request);
        Task<LoginResponse> FacebookLoginAsync(OAuthLoginRequest request);
    }
}