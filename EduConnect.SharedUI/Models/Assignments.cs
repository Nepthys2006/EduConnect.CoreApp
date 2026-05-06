using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class Assignment
    {
        [Required]
        [MaxLength(36)]
        public string AssignmentId { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string AssignmentTitle { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string AssignmentDescription { get; set; } = string.Empty;

        [Required]
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DueDate { get; set; }

        public double TotalPoints { get; set; }

        [Required]
        [MaxLength(50)]
        public string AssignmentType { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string AssignmentStatus { get; set; } = "Draft";

        [MaxLength(1000)]
        public string? Attachments { get; set; }

        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Class? Class { get; set; }
    }
}