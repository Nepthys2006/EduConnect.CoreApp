namespace EduConnect.SharedUI.Models;

public class AppUser
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string? LRN { get; set; }
    public string? StaffId { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Gender { get; set; }
    public DateOnly? Birthday { get; set; }
    public string? EducationLevel { get; set; }
    public string? PhoneNumber { get; set; }
    public string? MailingAddress { get; set; }
    public string? Website { get; set; }
}
