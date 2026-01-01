using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Fepa.API;

namespace Fepa.API.Tests
{
    /*
    public class SecurityTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public SecurityTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        // [Fact]
        // public async Task SqlInjection_EmailInput_ShouldBeProtected()
        // {
        //     var maliciousEmail = "'; DROP TABLE Users; --";
        //     var content = new { email = maliciousEmail, password = "pass" };
        //     var response = await _client.PostAsJsonAsync("/api/auth/login", content);
        //     // Should not actually execute SQL injection
        //     Assert.True(response.StatusCode != System.Net.HttpStatusCode.InternalServerError);
        // }

        // [Fact]
        // public async Task UnauthorizedAccess_WithoutToken_ShouldBeDenied()
        // {
        //     var response = await _client.GetAsync("/api/users/profile");
        //     Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        // }

        // [Fact]
        // public async Task TokenTampering_ModifiedJwt_ShouldBeDenied()
        // {
        //     var tamperedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIn0.FAKE";
        //     _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tamperedToken);
        //     var response = await _client.GetAsync("/api/users/profile");
        //     Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        // }

        // [Fact]
        // public void PasswordHash_ShouldNotBeReversible()
        // {
        //     var password = "MySecurePassword123!";
        //     var hash = BCrypt.Net.BCrypt.HashPassword(password);
        //     // Should not be able to reverse the hash
        //     Assert.NotEqual(password, hash);
        //     // But verification should work
        //     Assert.True(BCrypt.Net.BCrypt.Verify(password, hash));
        // }

        // [Fact]
        // public async Task RateLimiting_MultipleFailedLogins_ShouldLockAccount()
        // {
        //     for (int i = 0; i < 5; i++)
        //     {
        //         var content = new { email = "test@ex.com", password = "wrong" };
        //         await _client.PostAsJsonAsync("/api/auth/login", content);
        //     }
        //     // Next attempt should be locked
        //     var response = await _client.PostAsJsonAsync("/api/auth/login", new { email = "test@ex.com", password = "correct" });
        //     Assert.Equal(System.Net.HttpStatusCode.TooManyRequests, response.StatusCode);
        // }
    }
    */
}
