using Fepa.Domain.Entities;

namespace Fepa.Application.Interfaces
{
    public interface IVerificationTokenRepository
    {
        Task<VerificationToken?> GetByTokenAsync(string token);
        Task<VerificationToken?> GetByIdAsync(Guid id);
        Task<IEnumerable<VerificationToken>> GetByUserIdAndTypeAsync(Guid userId, string type);
        Task AddAsync(VerificationToken token);
        Task MarkAsUsedAsync(Guid id);
        Task DeleteExpiredAsync();
    }
}
