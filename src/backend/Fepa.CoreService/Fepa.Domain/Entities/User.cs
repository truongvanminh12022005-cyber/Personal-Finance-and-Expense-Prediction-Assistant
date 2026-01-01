namespace Fepa.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // Mật khẩu đã mã hóa
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // NEW: Email & 2FA Verification
        public bool IsEmailVerified { get; set; } = false;
        public DateTime? EmailVerifiedAt { get; set; }
        
        // NEW: Two-Factor Authentication
        public bool IsTwoFactorEnabled { get; set; } = false;
        public string? TwoFactorSecret { get; set; } // TOTP secret key
        
        // NEW: Optional phone for SMS 2FA
        public string? PhoneNumber { get; set; }
        public bool IsPhoneVerified { get; set; } = false;
        
        // NEW: OAuth Accounts
        public string? GoogleId { get; set; }
        public string? FacebookId { get; set; }
        
        // NEW: Last login tracking
        public DateTime? LastLoginAt { get; set; }
        public DateTime? PasswordChangedAt { get; set; }
        
        // NEW: Account status
        public bool IsActive { get; set; } = true;
        public DateTime? DeactivatedAt { get; set; }
    }
}