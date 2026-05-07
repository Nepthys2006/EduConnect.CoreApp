namespace EduConnect.SharedUI.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public int SubmittedCount { get; set; }
    public int TotalCount { get; set; }
}
