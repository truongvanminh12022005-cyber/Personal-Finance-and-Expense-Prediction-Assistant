namespace Fepa.Domain.Entities
{
    public class VerificationToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "EmailVerification", "PasswordReset", "PhoneVerification"
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UsedAt { get; set; }
        public bool IsUsed => UsedAt != null;
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsValid => !IsUsed && !IsExpired;

        // Navigation property
        public User? User { get; set; }
    }
}
