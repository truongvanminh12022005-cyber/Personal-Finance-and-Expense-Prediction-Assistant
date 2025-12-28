using Fepa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fepa.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // 1. Lấy DbContext ra
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FepaDbContext>();

            // 2. Tự động chạy Migration (Tạo bảng nếu chưa có) -> Cực tiện, khỏi gõ lệnh
            try 
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Loi Migration: {ex.Message}");
                // Nếu lỗi kết nối DB thì return luôn, không seed nữa
                return;
            }

            // 3. Kiểm tra xem đã có User nào chưa (Nếu có rồi thì thôi không tạo nữa)
            if (await context.Users.AnyAsync()) return;

            Console.WriteLine("--> DANG KHOI TAO DU LIEU MAU (SEEDING)...");

            // 4. Tạo Admin Mặc Định
            var adminUser = new User
            {
                Id = Guid.NewGuid(), // Hoặc cố định Guid.Parse("...") nếu muốn
                FullName = "System Admin",
                Email = "admin@fepa.com",
                PasswordHash = "123456", // Lưu ý: Đang dùng code so sánh thường
                Role = "Admin",
                //Status = "Active",
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(adminUser);
            
            // 5. (Optional) Tạo sẵn vài Danh mục chi tiêu mẫu luôn cho tiện
            // var cat1 = new Category { Name = "Ăn uống", Type = "Expense", ... };
            // await context.Categories.AddAsync(cat1);

            await context.SaveChangesAsync();
            
            Console.WriteLine("--> DA TAO USER ADMIN: admin@fepa.com / 123456");
        }
    }
}