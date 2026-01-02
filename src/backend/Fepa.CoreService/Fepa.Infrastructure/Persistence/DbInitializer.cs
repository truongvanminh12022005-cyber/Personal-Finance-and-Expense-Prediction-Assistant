using Fepa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Fepa.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FepaDbContext>();

            try 
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Loi Migration: {ex.Message}");
                return;
            }

            // Kiểm tra nếu admin đã tồn tại
            var existingAdmin = await context.Users.FirstOrDefaultAsync(u => u.Email == "admin@fepa.com");
            if (existingAdmin != null) return;

            Console.WriteLine("--> DANG KHOI TAO USER ADMIN...");

            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                FullName = "System Admin",
                Email = "admin@fepa.com",
                // Mã hóa 123456 để khớp với AuthService
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"), 
                Role = "Admin",
                IsActive = true,
                IsEmailVerified = true,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();
            
            Console.WriteLine("--> DA TAO ADMIN: admin@fepa.com / 123456");
        }
    }
}