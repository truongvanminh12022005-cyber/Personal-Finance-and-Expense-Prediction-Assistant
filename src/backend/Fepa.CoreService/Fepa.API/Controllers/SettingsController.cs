using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fepa.Infrastructure.Persistence;
using Fepa.Domain.Entities;

namespace Fepa.API.Controllers
{
    // 👇 1. THÊM CLASS NÀY ĐỂ NHẬN DỮ LIỆU GỌN NHẸ TỪ FRONTEND
    public class SettingUpdateDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly FepaDbContext _context;

        public SettingsController(FepaDbContext context)
        {
            _context = context;
        }

        // 1. Lấy tất cả cấu hình (Giữ nguyên)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var settings = await _context.SystemSettings.ToListAsync();

            if (!settings.Any())
            {
                settings = new List<SystemSetting>
                {
                    new SystemSetting { Key = "IS_MAINTENANCE", Value = "false", Group = "General", Description = "Bảo trì hệ thống (Tắt App)" },
                    new SystemSetting { Key = "OCR_LIMIT_DAILY", Value = "5", Group = "Feature", Description = "Giới hạn lượt quét hóa đơn miễn phí/ngày" },
                    new SystemSetting { Key = "MAX_UPLOAD_SIZE", Value = "10", Group = "System", Description = "Dung lượng ảnh tối đa (MB)" },
                    new SystemSetting { Key = "WARNING_THRESHOLD", Value = "80", Group = "Finance", Description = "Cảnh báo khi chi tiêu vượt quá (%)" }
                };
                _context.SystemSettings.AddRange(settings);
                await _context.SaveChangesAsync();
            }
            return Ok(settings);
        }

        // 👇 2. CẬP NHẬT (ĐÃ SỬA ĐỂ DÙNG DTO)
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] List<SettingUpdateDto> updates)
        {
            foreach (var update in updates)
            {
                var setting = await _context.SystemSettings.FindAsync(update.Key);
                if (setting != null)
                {
                    // Chỉ cập nhật giá trị Value, giữ nguyên Description và Group
                    setting.Value = update.Value;
                }
            }
            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã lưu cấu hình hệ thống!" });
        }
    }
}