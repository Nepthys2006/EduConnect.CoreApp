using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class Submission
    {
        [Required]
        [MaxLength(36)]
        public string SubmissionId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string AssignmentId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string StudentId { get; set; } = string.Empty;

        public double? Score { get; set; }

        [MaxLength(1000)]
        public string? FileUrl { get; set; }

        [MaxLength(255)]
        public string? FileName { get; set; }

        public DateTime? SubmittedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User? Student { get; set; }
        public Assignment? Assignment { get; set; }
    }
}
