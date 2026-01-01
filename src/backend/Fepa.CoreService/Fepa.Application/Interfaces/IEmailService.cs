namespace Fepa.Application.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Gửi email xác minh
        /// </summary>
        Task SendEmailVerificationAsync(string email, string verificationLink, string fullName);

        /// <summary>
        /// Gửi email reset password
        /// </summary>
        Task SendPasswordResetEmailAsync(string email, string resetLink, string fullName);

        /// <summary>
        /// Gửi email thông báo
        /// </summary>
        Task SendNotificationEmailAsync(string email, string subject, string message);

        /// <summary>
        /// Gửi email chào mừng
        /// </summary>
        Task SendWelcomeEmailAsync(string email, string fullName);
    }
}
