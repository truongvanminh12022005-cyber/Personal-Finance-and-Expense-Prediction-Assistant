namespace Fepa.Application.Interfaces
{
    public interface IOtpService
    {
        /// <summary>
        /// Tạo TOTP secret cho user
        /// </summary>
        string GenerateTotpSecret();

        /// <summary>
        /// Tạo QR code URL cho TOTP
        /// </summary>
        string GenerateQrCodeUrl(string email, string secret);

        /// <summary>
        /// Xác minh TOTP code
        /// </summary>
        bool VerifyTotpCode(string secret, string code);

        /// <summary>
        /// Tạo backup codes
        /// </summary>
        List<string> GenerateBackupCodes(int count = 10);

        /// <summary>
        /// Xác minh backup code
        /// </summary>
        bool VerifyBackupCode(string backupCodesJson, string code);
    }
}
