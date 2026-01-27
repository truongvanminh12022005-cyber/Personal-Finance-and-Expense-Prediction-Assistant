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


        public DbSet<VerificationToken> VerificationTokens { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}