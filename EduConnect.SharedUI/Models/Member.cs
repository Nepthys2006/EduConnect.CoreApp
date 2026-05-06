using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class Member
    {
        [Required]
        [MaxLength(36)]
        public string MemberId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "Student";

        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public User? User { get; set; }
        public Class? Class { get; set; }
    }
}