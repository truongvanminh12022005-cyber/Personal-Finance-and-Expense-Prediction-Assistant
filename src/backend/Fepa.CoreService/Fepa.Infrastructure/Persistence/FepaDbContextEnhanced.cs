using Fepa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fepa.Infrastructure.Persistence
{
    /*
    public static class FepaDbContextEnhanced
    {
        // public static void ConfigureAuthEntities(this ModelBuilder modelBuilder)
        // {
        //     // Configure RefreshToken entity
        //     modelBuilder.Entity<RefreshToken>()
        //         .HasKey(rt => rt.Id);
        //     modelBuilder.Entity<RefreshToken>()
        //         .Property(rt => rt.Token)
        //         .IsRequired();
        //     modelBuilder.Entity<RefreshToken>()
        //         .HasOne<User>()
        //         .WithMany()
        //         .HasForeignKey(rt => rt.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //     modelBuilder.Entity<RefreshToken>()
        //         .HasIndex(rt => rt.Token)
        //         .IsUnique();
        //     modelBuilder.Entity<RefreshToken>()
        //         .HasIndex(rt => rt.UserId);

        //     // Configure VerificationToken entity
        //     modelBuilder.Entity<VerificationToken>()
        //         .HasKey(vt => vt.Id);
        //     modelBuilder.Entity<VerificationToken>()
        //         .Property(vt => vt.Token)
        //         .IsRequired();
        //     modelBuilder.Entity<VerificationToken>()
        //         .Property(vt => vt.Type)
        //         .IsRequired()
        //         .HasMaxLength(50);
        //     modelBuilder.Entity<VerificationToken>()
        //         .HasOne<User>()
        //         .WithMany()
        //         .HasForeignKey(vt => vt.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //     modelBuilder.Entity<VerificationToken>()
        //         .HasIndex(vt => vt.Token)
        //         .IsUnique();
        //     modelBuilder.Entity<VerificationToken>()
        //         .HasIndex(vt => new { vt.UserId, vt.Type });

        //     // Configure TwoFactorSecret entity (if separate table)
        //     modelBuilder.Entity<TwoFactorSecret>()
        //         .HasKey(tfs => tfs.Id);
        //     modelBuilder.Entity<TwoFactorSecret>()
        //         .Property(tfs => tfs.Secret)
        //         .IsRequired();
        //     modelBuilder.Entity<TwoFactorSecret>()
        //         .HasOne<User>()
        //         .WithOne()
        //         .HasForeignKey<TwoFactorSecret>(tfs => tfs.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);

        //     // Configure User entity additional properties
        //     modelBuilder.Entity<User>()
        //         .HasIndex(u => u.GoogleId)
        //         .IsUnique();
        //     modelBuilder.Entity<User>()
        //         .HasIndex(u => u.FacebookId)
        //         .IsUnique();
        //     modelBuilder.Entity<User>()
        //         .Property(u => u.PhoneNumber)
        //         .HasMaxLength(20);
        // }
    }
    */
}
