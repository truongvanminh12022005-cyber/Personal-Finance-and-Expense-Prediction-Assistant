using System;
using System.ComponentModel.DataAnnotations;

namespace Fepa.Domain.Entities
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty; 

        [Required]
        public string Content { get; set; } = string.Empty; 

        public string? ImageUrl { get; set; } 

        public string Author { get; set; } = "Admin"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}