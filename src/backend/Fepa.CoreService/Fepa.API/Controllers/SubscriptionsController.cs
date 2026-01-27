using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fepa.Infrastructure.Persistence;
using Fepa.Domain.Entities;

namespace Fepa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly FepaDbContext _context;

        public SubscriptionsController(FepaDbContext context)
        {
            _context = context;
        }

        // GET: Lấy danh sách gói
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plans = await _context.SubscriptionPlans.ToListAsync();

            // Nếu chưa có gói nào thì tạo mẫu (Seed data)
            if (!plans.Any())
            {
                plans = new List<SubscriptionPlan>
                {
                    new SubscriptionPlan { Name = "Gói Tháng", Price = 49000, DurationInDays = 30, Description = "Mở khóa OCR;Không giới hạn ngân sách;Báo cáo nâng cao" },
                    new SubscriptionPlan { Name = "Gói Năm", Price = 499000, DurationInDays = 365, Description = "Tiết kiệm 20%;Mở khóa toàn bộ tính năng;Hỗ trợ 24/7" }
                };
                _context.SubscriptionPlans.AddRange(plans);
                await _context.SaveChangesAsync();
            }

            return Ok(plans);
        }

        // PUT: Cập nhật giá tiền hoặc tên gói
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubscriptionPlan plan)
        {
            var existing = await _context.SubscriptionPlans.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = plan.Name;
            existing.Price = plan.Price;
            existing.Description = plan.Description;
            existing.IsActive = plan.IsActive;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật gói cước thành công!" });
        }
    }
}