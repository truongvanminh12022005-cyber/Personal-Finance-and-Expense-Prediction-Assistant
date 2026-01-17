using Fepa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
// Thêm thư viện này để mã hóa mật khẩu
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

            if (await context.Users.AnyAsync()) return;

            Console.WriteLine("--> DANG KHOI TAO DU LIEU MAU (SEEDING)...");

            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                FullName = "System Admin",
                Email = "admin@fepa.com",
                // --- SỬA Ở ĐÂY: MÃ HÓA MẬT KHẨU ---
                // Mật khẩu là "123456" nhưng được mã hóa thành chuỗi ký tự loằng ngoằng
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"), 
                // ---------------------------------
                Role = "Admin",
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();
            
            Console.WriteLine("--> DA TAO USER ADMIN: admin@fepa.com / 123456");
        }
    }
}