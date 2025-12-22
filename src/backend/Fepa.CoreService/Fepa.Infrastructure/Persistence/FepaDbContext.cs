using Fepa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fepa.Infrastructure.Persistence
{
    public class FepaDbContext : DbContext
    {
        public FepaDbContext(DbContextOptions<FepaDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tại đây có thể cấu hình thêm (ví dụ: Email là duy nhất)
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}