using Fepa.Domain.Entities;

namespace Fepa.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<RefreshToken?> GetByIdAsync(Guid id);
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId);
        Task AddAsync(RefreshToken token);
        Task RevokeAsync(Guid id);
        Task RevokeAllByUserIdAsync(Guid userId);
        Task DeleteExpiredAsync();
    }
}
