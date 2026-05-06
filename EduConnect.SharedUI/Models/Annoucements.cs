using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduConnect.SharedUI.Models
{
    public class Announcement
    {
        [Required]
        [MaxLength(36)]
        public string AnnouncementId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        [ForeignKey(nameof(Author))]
        public string AnnouncementAuthorId { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string AnnouncementTitle { get; set; } = string.Empty;

        [Required]
        public string AnnouncementDescription { get; set; } = string.Empty;

        [Required]
        public DateTime AnnouncementDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Attachments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public User? Author { get; set; }
        public Class? Class { get; set; }
    }
}