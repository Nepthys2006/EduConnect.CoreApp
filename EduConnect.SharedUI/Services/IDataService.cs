using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services;

public interface IDataService
{
    // Classes
    Task<List<ClassRoom>> GetClassesAsync(Guid teacherId);
    Task<ClassRoom?> GetClassByIdAsync(Guid classId);
    Task<ClassRoom> CreateClassAsync(ClassRoom classroom);

    // Assignments
    Task<List<Assignment>> GetAssignmentsAsync(Guid classRoomId);
    Task<Assignment> CreateAssignmentAsync(Assignment assignment);

    // Submissions
    Task<List<Submission>> GetSubmissionsAsync(Guid assignmentId);
    Task UpdateScoreAsync(Guid submissionId, int score, string? feedback);

    // Members
    Task<List<AppUser>> GetMembersAsync(Guid classRoomId);
    Task<List<ClassMember>> GetPendingRequestsAsync(Guid classRoomId);
    Task AcceptMemberAsync(Guid classRoomId, Guid userId);
    Task RejectMemberAsync(Guid classRoomId, Guid userId);

    // Announcements
    Task<List<Announcement>> GetAnnouncementsAsync(Guid classRoomId);
    Task<Announcement> PostAnnouncementAsync(Announcement announcement);

    // Content
    Task<List<ContentModule>> GetModulesAsync(Guid classRoomId);
    Task<ContentModule> CreateModuleAsync(ContentModule module);

    // Attendance
    Task<List<AttendanceRecord>> GetAttendanceAsync(Guid classRoomId, DateOnly date);
    Task RecordAttendanceAsync(AttendanceRecord record);
    Task<List<DateOnly>> GetAttendanceDatesAsync(Guid classRoomId);

    // Messages
    Task<List<Conversation>> GetConversationsAsync(Guid userId);
    Task<List<Message>> GetMessagesAsync(Guid conversationId);
    Task SendMessageAsync(Message message);

    // Calendar
    Task<List<CalendarEvent>> GetEventsAsync(Guid teacherId, int year, int month);

    // Activity
    Task<List<ActivityItem>> GetActivityFeedAsync(Guid userId);

    // Dashboard
    Task<List<TodoItem>> GetTodoItemsAsync(Guid teacherId);
    Task<List<ClassRoom>> GetUpcomingClassesAsync(Guid teacherId);

    // Users
    Task<AppUser?> GetUserByIdAsync(Guid userId);
    Task<List<AppUser>> GetAllStudentsAsync();
    Task UpdateUserAsync(AppUser user);
}
