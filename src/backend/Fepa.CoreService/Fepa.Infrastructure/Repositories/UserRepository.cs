using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Fepa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fepa.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FepaDbContext _context;

        public UserRepository(FepaDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}