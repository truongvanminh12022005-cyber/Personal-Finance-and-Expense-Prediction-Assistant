
using Fepa.Domain.Entities;

namespace Fepa.Application.Interfaces
{
    public interface ITokenService
    {
     
        string GenerateAccessToken(User user);

     
        string GenerateRefreshToken();

     
        Task<RefreshToken?> ValidateRefreshTokenAsync(string token);

      
        string GenerateVerificationToken();

   
        List<string> GenerateBackupCodes(int count = 10);
    }
}
