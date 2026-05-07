namespace EduConnect.SharedUI.Models;

public class CalendarEvent
{
    public Guid Id { get; set; }
    public Guid? ClassRoomId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Color { get; set; } = "#2563EB";
    public string? Category { get; set; }
}
