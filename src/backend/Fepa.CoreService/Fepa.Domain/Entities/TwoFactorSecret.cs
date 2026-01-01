namespace Fepa.Domain.Entities
{
    public class TwoFactorSecret
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Secret { get; set; } = string.Empty; // TOTP Secret Key
        public string BackupCodes { get; set; } = string.Empty; // Comma-separated backup codes
        public bool IsConfirmed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ConfirmedAt { get; set; }

        // Navigation property
        public User? User { get; set; }
    }
}
