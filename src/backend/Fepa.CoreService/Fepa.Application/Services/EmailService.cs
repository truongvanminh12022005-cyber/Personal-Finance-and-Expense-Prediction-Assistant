using System.Net;
using System.Net.Mail;
using Fepa.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fepa.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // --- HÀM GỬI MAIL TRUNG TÂM ---
        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                // THÔNG TIN CẤU HÌNH CỨNG (Để test cho chạy 100%)
                var fromAddress = "nguyenthingoctram7524@gmail.com";
                var smtpUser = "nguyenthingoctram7524@gmail.com";
                var smtpPass = "osnhvluqpglzlulp"; // Mật khẩu ứng dụng của bạn
                var smtpHost = "smtp.gmail.com";
                var smtpPort = 587;

                _logger.LogInformation($"[Backend] Đang gửi mail tới: {toEmail}...");

                var client = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromAddress, "FEPA Support"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);

                // In ra Terminal để bạn nhìn thấy
                Console.WriteLine($"✅ [THÀNH CÔNG] Đã gửi mail cho {toEmail}");
                _logger.LogInformation($"✅ Đã gửi mail thành công tới {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [LỖI] Gửi mail thất bại: {ex.Message}");
                _logger.LogError($"❌ Lỗi gửi mail: {ex.Message}");
                throw;
            }
        }

        // Các hàm chức năng (Bắt buộc phải có đủ 4 hàm này để không lỗi Interface)
        public async Task SendEmailVerificationAsync(string email, string token, string name)
        {
            var subject = "Mã xác thực FEPA";
            var body = $"<h3>Chào {name},</h3><p>Mã của bạn là: <b>{token}</b></p>";
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetLink, string name)
        {
            var subject = "Đặt lại mật khẩu FEPA";
            var body = $@"
                <h3>Xin chào {name},</h3>
                <p>Bạn đã yêu cầu lấy lại mật khẩu.</p>
                <p>Vui lòng bấm vào link dưới đây để đặt lại mật khẩu mới:</p>
                <p><a href='{resetLink}' style='color:blue; font-weight:bold;'>BẤM VÀO ĐÂY ĐỂ ĐẶT LẠI MẬT KHẨU</a></p>
                <p>Nếu không phải bạn, vui lòng bỏ qua email này.</p>";
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendNotificationEmailAsync(string email, string subject, string message)
        {
            await SendEmailAsync(email, subject, $"<p>{message}</p>");
        }

        public async Task SendWelcomeEmailAsync(string email, string name)
        {
             await SendEmailAsync(email, "Chào mừng đến với FEPA", $"Xin chào {name}, cảm ơn bạn đã tham gia!");
        }
    }
}