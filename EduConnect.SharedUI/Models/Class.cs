using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduConnect.SharedUI.Models
{
    public class Class
    {
        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Grade { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Section { get; set; } = string.Empty;

        [MaxLength(20)]
        public string SchoolYear { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        [ForeignKey(nameof(Instructor))]
        public string InstructorId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public User? Instructor { get; set; }
        public List<Assignment> Assignments { get; set; } = new();
        public List<Announcement> Announcements { get; set; } = new();
        public List<Folder> Folders { get; set; } = new();
        public List<Member> Members { get; set; } = new();
    }
}