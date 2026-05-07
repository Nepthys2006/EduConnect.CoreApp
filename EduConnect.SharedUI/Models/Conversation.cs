namespace EduConnect.SharedUI.Models;

public class Conversation
{
    public Guid Id { get; set; }
    public List<Guid> ParticipantIds { get; set; } = new();
    public Guid? ClassRoomId { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsGroup { get; set; }
    public DateTime LastMessageAt { get; set; }
    public string LastMessagePreview { get; set; } = string.Empty;
    public int UnreadCount { get; set; }
}
