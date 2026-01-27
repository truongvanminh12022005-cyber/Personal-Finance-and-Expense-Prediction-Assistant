namespace Fepa.Application.DTOs.Admin
{
    public class DashboardDto
    {
        public decimal TotalRevenue { get; set; }
        public int NewUsersToday { get; set; }
        public int PendingOrders { get; set; }
        // Khởi tạo List rỗng để tránh lỗi null
        public List<RecentTransactionDto> RecentTransactions { get; set; } = new List<RecentTransactionDto>();
    }

    public class RecentTransactionDto
    {
        public string UserName { get; set; } = string.Empty; // Tránh null
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty; // Tránh null
    }
}