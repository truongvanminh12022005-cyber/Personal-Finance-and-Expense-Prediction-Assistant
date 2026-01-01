using Xunit;
using Fepa.Application.Services;
using System.Diagnostics;

namespace Fepa.API.Tests
{
    /*
    public class PerformanceTests
    {
        private readonly TokenService _tokenService;
        private readonly OtpService _otpService;

        public PerformanceTests()
        {
            _tokenService = new TokenService(null);
            _otpService = new OtpService();
        }

        // [Fact]
        // public void JwtGeneration_1000Iterations_ShouldComplete_InLessThan1Second()
        // {
        //     var sw = Stopwatch.StartNew();
        //     for (int i = 0; i < 1000; i++)
        //     {
        //         var user = new User { Id = Guid.NewGuid(), Email = "test@ex.com" };
        //         var token = _tokenService.GenerateAccessToken(user);
        //     }
        //     sw.Stop();
        //     Assert.True(sw.ElapsedMilliseconds < 1000, $"JWT generation took {sw.ElapsedMilliseconds}ms");
        // }

        // [Fact]
        // public void TotpVerification_1000Iterations_ShouldBeFast()
        // {
        //     var secret = _otpService.GenerateTotpSecret();
        //     var code = "123456";  // Example code
        //     var sw = Stopwatch.StartNew();
        //     for (int i = 0; i < 1000; i++)
        //     {
        //         _otpService.VerifyTotpCode(secret, code);
        //     }
        //     sw.Stop();
        //     Assert.True(sw.ElapsedMilliseconds < 2000);
        // }

        // [Fact]
        // public void PasswordHashing_100Iterations_ShouldBeFast()
        // {
        //     var password = "SecurePassword123!";
        //     var sw = Stopwatch.StartNew();
        //     for (int i = 0; i < 100; i++)
        //     {
        //         var hash = BCrypt.Net.BCrypt.HashPassword(password);
        //     }
        //     sw.Stop();
        //     Assert.True(sw.ElapsedMilliseconds < 10000, $"Password hashing took {sw.ElapsedMilliseconds}ms");
        // }
    }
    */
}
