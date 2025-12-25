using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Fepa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Fepa.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly FepaDbContext _context;

        public BlogRepository(FepaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            // Lấy danh sách, sắp xếp bài mới nhất lên đầu
            return await _context.Blogs.OrderByDescending(b => b.CreatedAt).ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(Guid id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task AddAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }
    }
}