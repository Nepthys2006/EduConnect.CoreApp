using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class User
    {
        [Required]
        [MaxLength(36)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;

        public long? LearnerReferenceNumber { get; set; }

        [Url]
        [MaxLength(500)]
        public string? AvatarUrl { get; set; }

        [MaxLength(20)]
        public string Role { get; set; } = "Student";

        public bool IsEmailVerified { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Class> TaughtClasses { get; set; } = new();
        public List<Announcement> Announcements { get; set; } = new();
        public List<Member> Memberships { get; set; } = new();
    }
}