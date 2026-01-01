using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Fepa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fepa.Infrastructure.Repositories
{
    public class VerificationTokenRepository : IVerificationTokenRepository
    {
        private readonly FepaDbContext _context;

        public VerificationTokenRepository(FepaDbContext context)
        {
            _context = context;
        }

        public async Task<VerificationToken?> GetByTokenAsync(string token)
        {
            return await _context.VerificationTokens.FirstOrDefaultAsync(vt => vt.Token == token);
        }

        public async Task<VerificationToken?> GetByIdAsync(Guid id)
        {
            return await _context.VerificationTokens.FindAsync(id);
        }

        public async Task<IEnumerable<VerificationToken>> GetByUserIdAndTypeAsync(Guid userId, string type)
        {
            return await _context.VerificationTokens
                .Where(vt => vt.UserId == userId && vt.Type == type && vt.IsValid)
                .ToListAsync();
        }

        public async Task AddAsync(VerificationToken token)
        {
            await _context.VerificationTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsUsedAsync(Guid id)
        {
            var token = await _context.VerificationTokens.FindAsync(id);
            if (token != null)
            {
                token.UsedAt = DateTime.UtcNow;
                _context.VerificationTokens.Update(token);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteExpiredAsync()
        {
            var expiredTokens = await _context.VerificationTokens
                .Where(vt => vt.IsExpired)
                .ToListAsync();

            _context.VerificationTokens.RemoveRange(expiredTokens);
            await _context.SaveChangesAsync();
        }
    }
}
