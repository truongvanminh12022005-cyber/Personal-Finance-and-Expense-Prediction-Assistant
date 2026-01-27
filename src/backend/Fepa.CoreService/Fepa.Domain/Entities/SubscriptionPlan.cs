using System.ComponentModel.DataAnnotations;

namespace Fepa.Domain.Entities
{
    public class SubscriptionPlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }        // Tên gói
        public decimal Price { get; set; }      // Giá tiền
        public int DurationInDays { get; set; } // Thời hạn
        public string Description { get; set; } // Mô tả quyền lợi
        public bool IsActive { get; set; } = true;
    }
}