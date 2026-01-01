using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Fepa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fepa.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly FepaDbContext _context;

        public RefreshTokenRepository(FepaDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.RefreshTokenValue == token);
        }

        public async Task<RefreshToken?> GetByIdAsync(Guid id)
        {
            return await _context.RefreshTokens.FindAsync(id);
        }

        public async Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId)
        {
            return await _context.RefreshTokens
                .Where(rt => rt.UserId == userId && rt.IsValid)
                .ToListAsync();
        }

        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task RevokeAsync(Guid id)
        {
            var token = await _context.RefreshTokens.FindAsync(id);
            if (token != null)
            {
                token.RevokedAt = DateTime.UtcNow;
                _context.RefreshTokens.Update(token);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RevokeAllByUserIdAsync(Guid userId)
        {
            var tokens = await _context.RefreshTokens
                .Where(rt => rt.UserId == userId && !rt.IsRevoked)
                .ToListAsync();

            foreach (var token in tokens)
            {
                token.RevokedAt = DateTime.UtcNow;
                _context.RefreshTokens.Update(token);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpiredAsync()
        {
            var expiredTokens = await _context.RefreshTokens
                .Where(rt => rt.IsExpired && rt.IsRevoked)
                .ToListAsync();

            _context.RefreshTokens.RemoveRange(expiredTokens);
            await _context.SaveChangesAsync();
        }
    }
}
