namespace EduConnect.SharedUI.Models;

public class Announcement
{
    public Guid Id { get; set; }
    public Guid ClassRoomId { get; set; }
    public Guid AuthorId { get; set; }
    public string Body { get; set; } = string.Empty;
    public DateTime PostedAt { get; set; }
    public List<ContentItem> Attachments { get; set; } = new();
}
