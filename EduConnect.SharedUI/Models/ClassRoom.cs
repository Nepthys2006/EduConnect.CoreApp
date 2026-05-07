namespace EduConnect.SharedUI.Models;

public class ClassRoom
{
    public Guid Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string GradeLevel { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public string SchoolYear { get; set; } = string.Empty;
    public Guid TeacherId { get; set; }
    public int GradientIndex { get; set; }
    public string? Schedule { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public List<ClassMember> Members { get; set; } = new();
}
