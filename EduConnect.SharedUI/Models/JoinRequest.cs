using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class JoinRequest
    {
        [Required]
        [MaxLength(36)]
        public string RequestId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string StudentId { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ResolvedAt { get; set; }

        public User? Student { get; set; }
        public Class? Class { get; set; }
    }
}
