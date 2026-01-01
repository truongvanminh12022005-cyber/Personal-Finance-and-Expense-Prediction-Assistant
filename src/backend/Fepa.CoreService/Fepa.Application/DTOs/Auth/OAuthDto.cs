namespace Fepa.Application.DTOs.Auth
{
    public class OAuthLoginRequest
    {
        public string Provider { get; set; } = string.Empty; // "Google", "Facebook"
        public string IdToken { get; set; } = string.Empty;
    }

    public class OAuthRegisterRequest
    {
        public string Provider { get; set; } = string.Empty; // "Google", "Facebook"
        public string IdToken { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
