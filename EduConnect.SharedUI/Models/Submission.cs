namespace EduConnect.SharedUI.Models;

public class Submission
{
    public Guid Id { get; set; }
    public Guid AssignmentId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public bool IsLate { get; set; }
    public int? Score { get; set; }
    public string? Feedback { get; set; }
}
