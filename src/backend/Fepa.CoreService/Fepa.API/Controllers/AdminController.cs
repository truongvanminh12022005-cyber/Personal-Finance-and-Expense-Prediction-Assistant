using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fepa.Application.DTOs.Admin;
using Fepa.Infrastructure.Persistence; // <--- DÒNG QUAN TRỌNG VỪA THÊM

namespace Fepa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly FepaDbContext _context;

        public AdminController(FepaDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard-stats")]
        public async Task<IActionResult> GetDashboardStats()
        {
            try
            {
                // Vì database của bạn có thể chưa có bảng Transactions,
                // mình sẽ tạm comment phần tính toán phức tạp để Test kết nối trước nhé.
                // Sau này khi tạo bảng xong thì mở comment ra.

                // 1. Đếm user mới đăng ký hôm nay (Cái này chắc chắn chạy được)
                var today = DateTime.UtcNow.Date;
                var newUsers = await _context.Users
                                .CountAsync(u => u.CreatedAt.Date == today);

                // 2. Dữ liệu giả lập cho các phần chưa có bảng (Để Dashboard hiện số đẹp)
                var result = new DashboardDto
                {
                    TotalRevenue = 15000000, // Giả lập 15 triệu
                    NewUsersToday = newUsers, // Số thật từ DB
                    PendingOrders = 5,
                    RecentTransactions = new List<RecentTransactionDto>
                    {
                        new RecentTransactionDto { UserName = "Nguyen Van A", Amount = 500000, Date = DateTime.Now, Status = "Success" },
                        new RecentTransactionDto { UserName = "Tran Thi B", Amount = 1200000, Date = DateTime.Now.AddDays(-1), Status = "Pending" }
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}