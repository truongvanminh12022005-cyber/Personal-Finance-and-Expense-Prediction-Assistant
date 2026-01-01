namespace Fepa.Application.DTOs.Auth
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; } // seconds
        public UserDto User { get; set; } = new();
        public bool RequiresTwoFactor { get; set; } = false;
    }
}
