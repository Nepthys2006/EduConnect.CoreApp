using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class CalendarEvent
    {
        [Required]
        [MaxLength(36)]
        public string EventId { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? EventType { get; set; }

        [MaxLength(36)]
        public string? ClassId { get; set; }

        [MaxLength(50)]
        public string? ClassColorPreset { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAllDay { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
