namespace EduConnect.SharedUI.Models;

public class Message
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public List<Guid> RecipientIds { get; set; } = new();
    public Guid? ClassRoomId { get; set; }
    public string Body { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    public bool IsGroupMessage { get; set; }
    public bool IsRead { get; set; }
}
