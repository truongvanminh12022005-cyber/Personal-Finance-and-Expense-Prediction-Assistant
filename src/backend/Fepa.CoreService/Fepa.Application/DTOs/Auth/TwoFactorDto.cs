namespace Fepa.Application.DTOs.Auth
{
    public class TwoFactorSetupResponse
    {
        public string Secret { get; set; } = string.Empty;
        public string QrCodeUrl { get; set; } = string.Empty;
        public List<string> BackupCodes { get; set; } = new();
    }

    public class VerifyTwoFactorRequest
    {
        public string Code { get; set; } = string.Empty; // 6-digit TOTP code
    }

    public class TwoFactorLoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string TwoFactorCode { get; set; } = string.Empty;
    }
}
