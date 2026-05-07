namespace EduConnect.SharedUI.Models;

public class AttendanceRecord
{
    public Guid Id { get; set; }
    public Guid ClassRoomId { get; set; }
    public Guid StudentId { get; set; }
    public DateOnly Date { get; set; }
    public AttendanceStatus Status { get; set; }
}
