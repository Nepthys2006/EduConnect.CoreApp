using System;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.SharedUI.Models
{
    public class Message
    {
        [Required]
        [MaxLength(36)]
        public string MessageId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string ConversationId { get; set; } = string.Empty;

        [Required]
        [MaxLength(36)]
        public string SenderId { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }

        public User? Sender { get; set; }
    }

    public class Conversation
    {
        [Required]
        [MaxLength(36)]
        public string ConversationId { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public User? OtherParticipant { get; set; }
        public Message? LastMessage { get; set; }
        public int UnreadCount { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
