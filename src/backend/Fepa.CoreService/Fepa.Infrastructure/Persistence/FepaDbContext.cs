using Fepa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fepa.Infrastructure.Persistence
{
    public class FepaDbContext : DbContext
    {
        public FepaDbContext(DbContextOptions<FepaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}