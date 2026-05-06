using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class ActivityItem
    {
        [Required]
        [MaxLength(36)]
        public string ActivityId { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? IconName { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }

        [MaxLength(36)]
        public string? RelatedClassId { get; set; }
    }
}
