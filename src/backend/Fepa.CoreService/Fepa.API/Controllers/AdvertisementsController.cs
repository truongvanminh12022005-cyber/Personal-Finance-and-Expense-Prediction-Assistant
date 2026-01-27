using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fepa.Infrastructure.Persistence;
using Fepa.Domain.Entities;

namespace Fepa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly FepaDbContext _context;

        public AdvertisementsController(FepaDbContext context)
        {
            _context = context;
        }

        // 1. LẤY DANH SÁCH (GET)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ads = await _context.Advertisements
                                    .OrderByDescending(a => a.CreatedAt)
                                    .ToListAsync();
            return Ok(ads);
        }

        // 2. TẠO MỚI (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Advertisement ad)
        {
            ad.CreatedAt = DateTime.UtcNow;
            _context.Advertisements.Add(ad);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Tạo quảng cáo thành công!", data = ad });
        }

        // 3. CẬP NHẬT (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Advertisement ad)
        {
            var existing = await _context.Advertisements.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Title = ad.Title;
            existing.ImageUrl = ad.ImageUrl;
            existing.TargetUrl = ad.TargetUrl;
            existing.PartnerName = ad.PartnerName;
            existing.ContractValue = ad.ContractValue;
            existing.StartDate = ad.StartDate;
            existing.EndDate = ad.EndDate;
            existing.IsActive = ad.IsActive;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật thành công!" });
        }

        // 4. XÓA (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ad = await _context.Advertisements.FindAsync(id);
            if (ad == null) return NotFound();

            _context.Advertisements.Remove(ad);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã xóa quảng cáo!" });
        }
    }
}