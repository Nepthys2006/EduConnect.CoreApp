using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services
{
    public interface IDataService
    {
        Task<User?> GetCurrentUserAsync();
        Task<List<Class>> GetTeacherClassesAsync(string teacherId);
        Task<Class?> GetClassAsync(string classId);
        Task<Class> CreateClassAsync(Class newClass);
        Task<List<Assignment>> GetClassAssignmentsAsync(string classId);
        Task<Assignment?> GetAssignmentAsync(string assignmentId);
        Task<List<Submission>> GetAssignmentSubmissionsAsync(string assignmentId);
        Task SaveGradeAsync(string submissionId, double? score);
        Task<List<Member>> GetClassMembersAsync(string classId);
        Task<List<JoinRequest>> GetPendingJoinRequestsAsync(string classId);
        Task AcceptJoinRequestAsync(string requestId);
        Task RejectJoinRequestAsync(string requestId);
        Task RemoveMemberAsync(string memberId);
        Task<List<Announcement>> GetClassAnnouncementsAsync(string classId);
        Task<Announcement> PostAnnouncementAsync(Announcement announcement);
        Task<List<Folder>> GetClassFoldersAsync(string classId);
        Task<List<AttendanceRecord>> GetAttendanceForDateAsync(string classId, DateTime date);
        Task SaveAttendanceAsync(AttendanceRecord record);
        Task MarkAllPresentAsync(string classId, DateTime date);
        Task<List<Conversation>> GetConversationsAsync(string userId);
        Task<List<Message>> GetMessagesAsync(string conversationId);
        Task SendMessageAsync(string conversationId, string senderId, string content);
        Task<List<ActivityItem>> GetActivitiesAsync(string userId, string? category = null);
        Task<List<CalendarEvent>> GetCalendarEventsAsync(string userId, DateTime month);
        Task<List<Submission>> GetRecentSubmissionsAsync(string teacherId, int count = 4);
    }
}
