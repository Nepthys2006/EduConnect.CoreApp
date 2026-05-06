using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class AttendanceRecord
    {
        [Required]
        [MaxLength(36)]
        public string AttendanceId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string StudentId { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Present";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User? Student { get; set; }
        public Class? Class { get; set; }
    }
}
