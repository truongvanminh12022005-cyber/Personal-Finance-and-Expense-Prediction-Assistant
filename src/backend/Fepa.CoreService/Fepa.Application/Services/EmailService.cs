using Fepa.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace Fepa.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;
        private readonly SmtpClient _smtpClient;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            var smtpSettings = _configuration.GetSection("Email:Smtp");
            _smtpClient = new SmtpClient
            {
                Host = smtpSettings["Host"] ?? "smtp.gmail.com",
                Port = int.Parse(smtpSettings["Port"] ?? "587"),
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    smtpSettings["Username"],
                    smtpSettings["Password"]
                )
            };
        }

        public async Task SendEmailVerificationAsync(string email, string verificationLink, string fullName)
        {
            try
            {
                var subject = "Xác minh Email - FEPA";
                var body = $@"
                    <h2>Xin chào {fullName},</h2>
                    <p>Vui lòng xác minh email của bạn bằng cách click vào link dưới đây:</p>
                    <a href='{verificationLink}'>Xác minh Email</a>
                    <p>Link này sẽ hết hạn sau 24 giờ.</p>
                    <p>Nếu bạn không yêu cầu xác minh này, vui lòng bỏ qua email này.</p>
                    <p>Trân trọng,<br/>FEPA Team</p>
                ";

                await SendEmailAsync(email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending verification email to {email}");
                throw;
            }
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetLink, string fullName)
        {
            try
            {
                var subject = "Đặt Lại Mật Khẩu - FEPA";
                var body = $@"
                    <h2>Xin chào {fullName},</h2>
                    <p>Bạn đã yêu cầu đặt lại mật khẩu. Click vào link dưới đây để tạo mật khẩu mới:</p>
                    <a href='{resetLink}'>Đặt Lại Mật Khẩu</a>
                    <p>Link này sẽ hết hạn sau 1 giờ.</p>
                    <p>Nếu bạn không yêu cầu này, vui lòng bỏ qua email này.</p>
                    <p>Trân trọng,<br/>FEPA Team</p>
                ";

                await SendEmailAsync(email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending password reset email to {email}");
                throw;
            }
        }

        public async Task SendNotificationEmailAsync(string email, string subject, string message)
        {
            try
            {
                var body = $@"
                    <h2>Thông báo từ FEPA</h2>
                    <p>{message}</p>
                    <p>Trân trọng,<br/>FEPA Team</p>
                ";

                await SendEmailAsync(email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending notification email to {email}");
                throw;
            }
        }

        public async Task SendWelcomeEmailAsync(string email, string fullName)
        {
            try
            {
                var subject = "Chào mừng đến FEPA!";
                var body = $@"
                    <h2>Xin chào {fullName},</h2>
                    <p>Chào mừng bạn đến với FEPA - Trợ lý Tài chính Cá nhân của bạn!</p>
                    <p>Tài khoản của bạn đã được tạo thành công. Bây giờ bạn có thể:</p>
                    <ul>
                        <li>Theo dõi chi tiêu của bạn</li>
                        <li>Lập ngân sách hàng tháng</li>
                        <li>Xem thống kê chi tiêu</li>
                    </ul>
                    <p>Nếu bạn cần hỗ trợ, vui lòng liên hệ với chúng tôi.</p>
                    <p>Trân trọng,<br/>FEPA Team</p>
                ";

                await SendEmailAsync(email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending welcome email to {email}");
                throw;
            }
        }

        private async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Email:FromAddress"] ?? "noreply@fepa.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                await _smtpClient.SendMailAsync(mailMessage);
                _logger.LogInformation($"Email sent successfully to {to}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending email to {to}");
                throw;
            }
        }
    }
}
