using Fepa.Application.Interfaces;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq; // Cần thêm dòng này để dùng .Select và .Contains
using System.Text;

namespace Fepa.Application.Services
{
    public class OtpService : IOtpService
    {
        public string GenerateTotpSecret()
        {
            // Tạo secret key ngẫu nhiên 32 bytes
            var key = KeyGeneration.GenerateRandomKey(32);
            return Base32Encoding.ToString(key);
        }

        public string GenerateQrCodeUrl(string email, string secret)
        {
            var encodedSecret = Uri.EscapeDataString(secret);
            var encodedEmail = Uri.EscapeDataString(email);
            // Tạo đường dẫn chuẩn cho Google Authenticator
            var qrCodeUrl = $"otpauth://totp/FEPA:{encodedEmail}?secret={encodedSecret}&issuer=FEPA";
            return qrCodeUrl;
        }

        public bool VerifyTotpCode(string secret, string code)
        {
            try
            {
                if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(code))
                {
                    return false;
                }

                var totp = new Totp(Base32Encoding.ToBytes(secret));
                
                // SỬA LỖI TẠI ĐÂY:
                // Sử dụng VerificationWindow thay vì TimeSpan.
                // previous: 1, future: 1 nghĩa là chấp nhận mã của 30s trước và 30s sau (để tránh lệch giờ).
                var window = new VerificationWindow(previous: 1, future: 1);

                return totp.VerifyTotp(code, out long timeStepMatched, window);
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
                // Tạo mã dự phòng 6 chữ số
                var code = random.Next(100000, 999999).ToString();
                codes.Add(code);
            }

            return codes;
        }

        public bool VerifyBackupCode(string backupCodesJson, string code)
        {
            try
            {
                if (string.IsNullOrEmpty(backupCodesJson))
                {
                    return false;
                }

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