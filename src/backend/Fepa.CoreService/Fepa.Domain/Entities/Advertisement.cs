using System;
using System.ComponentModel.DataAnnotations;

namespace Fepa.Domain.Entities
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }       // Tên chiến dịch
        public string PartnerName { get; set; } // Tên đối tác
        public decimal ContractValue { get; set; } // Giá trị hợp đồng
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }    // Link ảnh Banner
        public string TargetUrl { get; set; }   // Link khi bấm vào quảng cáo
        public bool IsActive { get; set; }      // Trạng thái bật/tắt
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}