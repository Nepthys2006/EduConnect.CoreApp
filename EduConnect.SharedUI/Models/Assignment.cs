namespace EduConnect.SharedUI.Models;

public class Assignment
{
    public Guid Id { get; set; }
    public Guid ClassRoomId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AssignmentType Type { get; set; }
    public DateTime DueDate { get; set; }
    public int MaxPoints { get; set; }
    public AssignmentStatus Status { get; set; }
}
