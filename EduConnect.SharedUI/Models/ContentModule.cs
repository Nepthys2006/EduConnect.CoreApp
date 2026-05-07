namespace EduConnect.SharedUI.Models;

public class ContentModule
{
    public Guid Id { get; set; }
    public Guid ClassRoomId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ItemCount { get; set; }
    public List<ContentItem> Items { get; set; } = new();
}
