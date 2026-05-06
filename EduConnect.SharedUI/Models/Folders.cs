using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduConnect.SharedUI.Models
{
    public class Folder
    {
        [Required]
        [MaxLength(36)]
        public string FolderId { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FolderName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(36)]
        public string ClassId { get; set; } = string.Empty;

        [MaxLength(36)]
        [ForeignKey(nameof(ParentFolder))]
        public string? ParentFolderId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Class? Class { get; set; }
        public Folder? ParentFolder { get; set; }
        public List<Folder> SubFolders { get; set; } = new();
        public List<string> ItemIds { get; set; } = new();
    }
}