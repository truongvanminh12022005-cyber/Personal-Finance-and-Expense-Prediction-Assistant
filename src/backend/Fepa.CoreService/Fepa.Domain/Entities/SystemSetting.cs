using System.ComponentModel.DataAnnotations;

namespace Fepa.Domain.Entities
{
    public class SystemSetting
    {
        [Key]
        public string Key { get; set; }     // Mã cài đặt (VD: IS_MAINTENANCE)
        public string Value { get; set; }   // Giá trị (VD: true/false/100)
        public string Description { get; set; } // Mô tả
        public string Group { get; set; }   // Nhóm (VD: General, Security)
    }
}