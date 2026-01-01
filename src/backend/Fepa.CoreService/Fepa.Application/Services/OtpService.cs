using Fepa.Application.Interfaces;
using OtpNet;
using System.Text;

namespace Fepa.Application.Services
{
    public class OtpService : IOtpService
    {
        public string GenerateTotpSecret()
        {
            var key = KeyGeneration.GenerateRandomKey(32);
            return Base32Encoding.ToString(key);
        }

        public string GenerateQrCodeUrl(string email, string secret)
        {
            var encodedSecret = Uri.EscapeDataString(secret);
            var encodedEmail = Uri.EscapeDataString(email);
            var qrCodeUrl = $"otpauth://totp/FEPA:{encodedEmail}?secret={encodedSecret}&issuer=FEPA";
            return qrCodeUrl;
        }

        public bool VerifyTotpCode(string secret, string code)
        {
            try
            {
                var totp = new Totp(Base32Encoding.ToBytes(secret));
                var timeTolerance = TimeSpan.FromSeconds(30);
                return totp.VerifyTotp(code, out var window, timeTolerance);
            }
            catch
            {
                return false;
            }
        }

        public List<string> GenerateBackupCodes(int count = 10)
        {
            var codes = new List<string>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var code = random.Next(100000, 999999).ToString();
                codes.Add(code);
            }

            return codes;
        }

        public bool VerifyBackupCode(string backupCodesJson, string code)
        {
            try
            {
                // Backup codes được lưu dưới dạng JSON array hoặc comma-separated
                var codes = backupCodesJson.Split(',').Select(c => c.Trim()).ToList();
                return codes.Contains(code);
            }
            catch
            {
                return false;
            }
        }
    }
}
