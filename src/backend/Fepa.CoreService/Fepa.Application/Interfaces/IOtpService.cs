namespace Fepa.Application.Interfaces
{
    public interface IOtpService
    {
        
        string GenerateTotpSecret();

        
        string GenerateQrCodeUrl(string email, string secret);

        
        bool VerifyTotpCode(string secret, string code);

        
        List<string> GenerateBackupCodes(int count = 10);


        bool VerifyBackupCode(string backupCodesJson, string code);
    }
}
