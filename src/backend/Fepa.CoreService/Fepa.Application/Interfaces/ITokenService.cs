using Fepa.Domain.Entities;

namespace Fepa.Application.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Tạo JWT access token
        /// </summary>
        string GenerateAccessToken(User user);

        /// <summary>
        /// Tạo refresh token
        /// </summary>
        string GenerateRefreshToken();

        /// <summary>
        /// Xác minh refresh token
        /// </summary>
        Task<RefreshToken?> ValidateRefreshTokenAsync(string token);

        /// <summary>
        /// Tạo verification token (email, password reset, v.v.)
        /// </summary>
        string GenerateVerificationToken();

        /// <summary>
        /// Tạo backup codes
        /// </summary>
        List<string> GenerateBackupCodes(int count = 10);
    }
}
