using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services
{
    public class MockDataService : IDataService
    {
        private static readonly List<string> GradientPresets = new()
        {
            "#6366F1,#818CF8", "#2563EB,#06B6D4", "#0EA5E9,#34D399",
            "#10B981,#A3E635", "#F59E0B,#F97316", "#EF4444,#EC4899"
        };

        private readonly List<User> _users;
        private readonly List<Class> _classes;
        private readonly List<Assignment> _assignments;
        private readonly List<Member> _members;
        private readonly List<Announcement> _announcements;
        private readonly List<Folder> _folders;
        private readonly List<AttendanceRecord> _attendance;
        private readonly List<Conversation> _conversations;
        private readonly List<Message> _messages;
        private readonly List<ActivityItem> _activities;
        private readonly List<CalendarEvent> _calendarEvents;
        private readonly List<Submission> _submissions;
        private readonly List<JoinRequest> _joinRequests;

        private readonly string _currentTeacherId = "teacher-001";
        private int _idCounter = 100;

        public MockDataService()
        {
            _users = new List<User>
            {
                new() { Id = "teacher-001", Name = "Maria Santos", Email = "m.santos@deped.gov.ph", Role = "Teacher", LearnerReferenceNumber = null, AvatarUrl = null },
                new() { Id = "student-001", Name = "Juan Dela Cruz", Email = "juan.cruz@gmail.com", Role = "Student", LearnerReferenceNumber = 123456789012L, AvatarUrl = null },
                new() { Id = "student-002", Name = "Maria Clara", Email = "maria.clara@gmail.com", Role = "Student", LearnerReferenceNumber = 123456789013L, AvatarUrl = null },
                new() { Id = "student-003", Name = "Jose Rizal", Email = "jose.rizal@gmail.com", Role = "Student", LearnerReferenceNumber = 123456789014L, AvatarUrl = null },
                new() { Id = "student-004", Name = "Andres Bonifacio", Email = "andres.bonifacio@gmail.com", Role = "Student", LearnerReferenceNumber = 123456789015L, AvatarUrl = null },
                new() { Id = "student-005", Name = "Gabriela Silang", Email = "gabriela.silang@gmail.com", Role = "Student", LearnerReferenceNumber = 123456789016L, AvatarUrl = null },
                new() { Id = "student-006", Name = "Lapu-Lapu", Email = "lapulapu@gmail.com", Role = "Student", LearnerReferenceNumber = 123456789017L, AvatarUrl = null },
            };

            _classes = new List<Class>
            {
                new() { ClassId = "class-001", Subject = "Mathematics 9", Grade = "9", Section = "Plato", SchoolYear = "2025-2026", InstructorId = "teacher-001", CreatedAt = DateTime.UtcNow.AddDays(-30) },
                new() { ClassId = "class-002", Subject = "Science 10", Grade = "10", Section = "Aristotle", SchoolYear = "2025-2026", InstructorId = "teacher-001", CreatedAt = DateTime.UtcNow.AddDays(-28) },
                new() { ClassId = "class-003", Subject = "English 8", Grade = "8", Section = "Socrates", SchoolYear = "2025-2026", InstructorId = "teacher-001", CreatedAt = DateTime.UtcNow.AddDays(-25) },
                new() { ClassId = "class-004", Subject = "Filipino 7", Grade = "7", Section = "Homer", SchoolYear = "2025-2026", InstructorId = "teacher-001", CreatedAt = DateTime.UtcNow.AddDays(-20) },
            };

            _members = new List<Member>
            {
                new() { MemberId = "m-001", UserId = "teacher-001", ClassId = "class-001", Role = "Teacher", JoinedDate = DateTime.UtcNow.AddDays(-30) },
                new() { MemberId = "m-002", UserId = "student-001", ClassId = "class-001", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-28) },
                new() { MemberId = "m-003", UserId = "student-002", ClassId = "class-001", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-27) },
                new() { MemberId = "m-004", UserId = "student-003", ClassId = "class-001", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-26) },
                new() { MemberId = "m-005", UserId = "teacher-001", ClassId = "class-002", Role = "Teacher", JoinedDate = DateTime.UtcNow.AddDays(-28) },
                new() { MemberId = "m-006", UserId = "student-001", ClassId = "class-002", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-26) },
                new() { MemberId = "m-007", UserId = "student-004", ClassId = "class-002", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-25) },
                new() { MemberId = "m-008", UserId = "student-005", ClassId = "class-002", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-24) },
                new() { MemberId = "m-009", UserId = "teacher-001", ClassId = "class-003", Role = "Teacher", JoinedDate = DateTime.UtcNow.AddDays(-25) },
                new() { MemberId = "m-010", UserId = "student-002", ClassId = "class-003", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-23) },
                new() { MemberId = "m-011", UserId = "student-006", ClassId = "class-003", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-22) },
                new() { MemberId = "m-012", UserId = "teacher-001", ClassId = "class-004", Role = "Teacher", JoinedDate = DateTime.UtcNow.AddDays(-20) },
                new() { MemberId = "m-013", UserId = "student-003", ClassId = "class-004", Role = "Student", JoinedDate = DateTime.UtcNow.AddDays(-18) },
            };

            _assignments = new List<Assignment>
            {
                new() { AssignmentId = "a-001", ClassId = "class-001", AssignmentTitle = "Algebraic Expressions Worksheet", AssignmentDescription = "Solve problems 1-20 on page 45 of your textbook.", DueDate = DateTime.UtcNow.Date.AddHours(23), TotalPoints = 50, AssignmentType = "Code", AssignmentStatus = "Ongoing", AssignedDate = DateTime.UtcNow.AddDays(-3) },
                new() { AssignmentId = "a-002", ClassId = "class-001", AssignmentTitle = "Quadratic Formula Quiz", AssignmentDescription = "15-minute timed quiz on solving quadratic equations.", DueDate = DateTime.UtcNow.Date.AddDays(1).AddHours(10), TotalPoints = 30, AssignmentType = "Quiz", AssignmentStatus = "Ongoing", AssignedDate = DateTime.UtcNow.AddDays(-2) },
                new() { AssignmentId = "a-003", ClassId = "class-002", AssignmentTitle = "Lab Report: Photosynthesis", AssignmentDescription = "Write a complete lab report following the scientific method.", DueDate = DateTime.UtcNow.Date.AddDays(3).AddHours(15), TotalPoints = 100, AssignmentType = "Essay", AssignmentStatus = "Pending", AssignedDate = DateTime.UtcNow.AddDays(-1) },
                new() { AssignmentId = "a-004", ClassId = "class-002", AssignmentTitle = "Cell Structure Diagram", AssignmentDescription = "Draw and label a plant and animal cell diagram.", DueDate = DateTime.UtcNow.Date.AddDays(5).AddHours(9), TotalPoints = 40, AssignmentType = "Project", AssignmentStatus = "Pending", AssignedDate = DateTime.UtcNow.AddDays(-1) },
                new() { AssignmentId = "a-005", ClassId = "class-003", AssignmentTitle = "Essay: Philippine Literature", AssignmentDescription = "500-word essay on the impact of Noli Me Tangere.", DueDate = DateTime.UtcNow.Date.AddDays(2).AddHours(14), TotalPoints = 75, AssignmentType = "Essay", AssignmentStatus = "Ongoing", AssignedDate = DateTime.UtcNow.AddDays(-4) },
            };

            _submissions = new List<Submission>
            {
                new() { SubmissionId = "s-001", AssignmentId = "a-001", StudentId = "student-001", Score = 45, FileUrl = "worksheet_juan.pdf", FileName = "worksheet_juan.pdf", SubmittedAt = DateTime.UtcNow.AddDays(-1) },
                new() { SubmissionId = "s-002", AssignmentId = "a-001", StudentId = "student-002", Score = null, FileUrl = "worksheet_maria.pdf", FileName = "worksheet_maria.pdf", SubmittedAt = DateTime.UtcNow.AddDays(-1).AddHours(-2) },
                new() { SubmissionId = "s-003", AssignmentId = "a-001", StudentId = "student-003", Score = null, FileUrl = null, FileName = null, SubmittedAt = null },
                new() { SubmissionId = "s-004", AssignmentId = "a-001", StudentId = "student-004", Score = 48, FileUrl = "worksheet_andres.pdf", FileName = "worksheet_andres.pdf", SubmittedAt = DateTime.UtcNow.AddDays(-2) },
                new() { SubmissionId = "s-005", AssignmentId = "a-002", StudentId = "student-001", Score = null, FileUrl = null, FileName = null, SubmittedAt = null },
                new() { SubmissionId = "s-006", AssignmentId = "a-003", StudentId = "student-001", Score = null, FileUrl = "lab_juan.pdf", FileName = "lab_juan.pdf", SubmittedAt = DateTime.UtcNow.AddHours(-3) },
            };

            _announcements = new List<Announcement>
            {
                new() { AnnouncementId = "ann-001", ClassId = "class-001", AnnouncementAuthorId = "teacher-001", AnnouncementTitle = "Midterm Exam Schedule", AnnouncementDescription = "The midterm exam will be held next Monday at 8:00 AM. Please bring a scientific calculator and two sheets of bond paper.", AnnouncementDate = DateTime.UtcNow.AddDays(-2), Attachments = null },
                new() { AnnouncementId = "ann-002", ClassId = "class-001", AnnouncementAuthorId = "teacher-001", AnnouncementTitle = "Assignment #3 Clarification", AnnouncementDescription = "For question 12, please use the quadratic formula method instead of factoring. The answer key has been updated.", AnnouncementDate = DateTime.UtcNow.AddDays(-1), Attachments = "answer_key.pdf" },
                new() { AnnouncementId = "ann-003", ClassId = "class-002", AnnouncementAuthorId = "teacher-001", AnnouncementTitle = "Lab Safety Reminder", AnnouncementDescription = "Remember to wear your lab coats and safety goggles during tomorrow's experiment session.", AnnouncementDate = DateTime.UtcNow.AddHours(-5), Attachments = null },
            };

            _folders = new List<Folder>
            {
                new() { FolderId = "f-001", ClassId = "class-001", FolderName = "Module 1: Number Systems", Description = "Introduction to real numbers, rational and irrational numbers.", ItemIds = new List<string> { "slide1.pdf", "handout1.pdf" } },
                new() { FolderId = "f-002", ClassId = "class-001", FolderName = "Module 2: Algebraic Expressions", Description = "Variables, constants, and algebraic terms.", ItemIds = new List<string> { "slide2.pdf", "worksheet2.docx" } },
                new() { FolderId = "f-003", ClassId = "class-002", FolderName = "Module 1: Cell Biology", Description = "Structure and function of cell organelles.", ItemIds = new List<string> { "cell_diagram.png", "notes.pdf" } },
            };

            _attendance = new List<AttendanceRecord>
            {
                new() { AttendanceId = "att-001", ClassId = "class-001", StudentId = "student-001", Date = DateTime.UtcNow.Date.AddDays(-1), Status = "Present" },
                new() { AttendanceId = "att-002", ClassId = "class-001", StudentId = "student-002", Date = DateTime.UtcNow.Date.AddDays(-1), Status = "Absent" },
                new() { AttendanceId = "att-003", ClassId = "class-001", StudentId = "student-003", Date = DateTime.UtcNow.Date.AddDays(-1), Status = "Present" },
                new() { AttendanceId = "att-004", ClassId = "class-001", StudentId = "student-001", Date = DateTime.UtcNow.Date, Status = "Present" },
                new() { AttendanceId = "att-005", ClassId = "class-001", StudentId = "student-002", Date = DateTime.UtcNow.Date, Status = "Present" },
            };

            _conversations = new List<Conversation>
            {
                new() { ConversationId = "conv-001", Title = "Juan Dela Cruz", OtherParticipant = _users[1], LastMessage = new Message { Content = "Ma'am, can I have an extension on the worksheet?", SentAt = DateTime.UtcNow.AddHours(-2) }, UnreadCount = 1, UpdatedAt = DateTime.UtcNow.AddHours(-2) },
                new() { ConversationId = "conv-002", Title = "Maria Clara", OtherParticipant = _users[2], LastMessage = new Message { Content = "Thank you for the feedback, Ma'am!", SentAt = DateTime.UtcNow.AddDays(-1) }, UnreadCount = 0, UpdatedAt = DateTime.UtcNow.AddDays(-1) },
                new() { ConversationId = "conv-003", Title = "Jose Rizal", OtherParticipant = _users[3], LastMessage = new Message { Content = "I submitted my essay. Please check when you have time.", SentAt = DateTime.UtcNow.AddDays(-2) }, UnreadCount = 0, UpdatedAt = DateTime.UtcNow.AddDays(-2) },
            };

            _messages = new List<Message>
            {
                new() { MessageId = "msg-001", ConversationId = "conv-001", SenderId = "student-001", Content = "Ma'am, can I have an extension on the worksheet?", SentAt = DateTime.UtcNow.AddHours(-3) },
                new() { MessageId = "msg-002", ConversationId = "conv-001", SenderId = "teacher-001", Content = "Sure, you have until Friday. Make sure to complete all problems.", SentAt = DateTime.UtcNow.AddHours(-2) },
                new() { MessageId = "msg-003", ConversationId = "conv-001", SenderId = "student-001", Content = "Thank you, Ma'am!", SentAt = DateTime.UtcNow.AddHours(-2).AddMinutes(-5) },
                new() { MessageId = "msg-004", ConversationId = "conv-002", SenderId = "student-002", Content = "Ma'am, where can I find the reading materials?", SentAt = DateTime.UtcNow.AddDays(-1).AddHours(-2) },
                new() { MessageId = "msg-005", ConversationId = "conv-002", SenderId = "teacher-001", Content = "Check the Content tab in our class. I uploaded them yesterday.", SentAt = DateTime.UtcNow.AddDays(-1).AddHours(-1) },
                new() { MessageId = "msg-006", ConversationId = "conv-002", SenderId = "student-002", Content = "Thank you for the feedback, Ma'am!", SentAt = DateTime.UtcNow.AddDays(-1) },
            };

            _activities = new List<ActivityItem>
            {
                new() { ActivityId = "act-001", Title = "Juan Dela Cruz submitted worksheet", Category = "Submissions", Timestamp = DateTime.UtcNow.AddMinutes(-10), IsRead = false, RelatedClassId = "class-001" },
                new() { ActivityId = "act-002", Title = "New message from Maria Clara", Category = "Messages", Timestamp = DateTime.UtcNow.AddMinutes(-25), IsRead = false, RelatedClassId = null },
                new() { ActivityId = "act-003", Title = "Created assignment 'Lab Report'", Category = "Alerts", Timestamp = DateTime.UtcNow.AddHours(-2), IsRead = true, RelatedClassId = "class-002" },
                new() { ActivityId = "act-004", Title = "Gabriela Silang submitted essay", Category = "Submissions", Timestamp = DateTime.UtcNow.AddHours(-3), IsRead = true, RelatedClassId = "class-002" },
                new() { ActivityId = "act-005", Title = "New join request from Andres Bonifacio", Category = "Alerts", Timestamp = DateTime.UtcNow.AddHours(-5), IsRead = true, RelatedClassId = "class-002" },
                new() { ActivityId = "act-006", Title = "Posted announcement in Math 9", Category = "Alerts", Timestamp = DateTime.UtcNow.AddDays(-1), IsRead = true, RelatedClassId = "class-001" },
            };

            _calendarEvents = new List<CalendarEvent>
            {
                new() { EventId = "evt-001", Title = "Math 9 - Lecture", EventType = "Class", ClassId = "class-001", ClassColorPreset = "1", StartDate = DateTime.UtcNow.Date.AddHours(8), EndDate = DateTime.UtcNow.Date.AddHours(9), IsAllDay = false },
                new() { EventId = "evt-002", Title = "Science 10 - Lab", EventType = "Class", ClassId = "class-002", ClassColorPreset = "2", StartDate = DateTime.UtcNow.Date.AddHours(10), EndDate = DateTime.UtcNow.Date.AddHours(12), IsAllDay = false },
                new() { EventId = "evt-003", Title = "Algebraic Expressions Due", EventType = "Assignment", ClassId = "class-001", ClassColorPreset = "1", StartDate = DateTime.UtcNow.Date.AddHours(23), IsAllDay = false },
                new() { EventId = "evt-004", Title = "English 8 - Discussion", EventType = "Class", ClassId = "class-003", ClassColorPreset = "3", StartDate = DateTime.UtcNow.Date.AddDays(1).AddHours(13), EndDate = DateTime.UtcNow.Date.AddDays(1).AddHours(14), IsAllDay = false },
                new() { EventId = "evt-005", Title = "Midterm Exam", EventType = "Exam", ClassId = "class-001", ClassColorPreset = "1", StartDate = DateTime.UtcNow.Date.AddDays(7).AddHours(8), EndDate = DateTime.UtcNow.Date.AddDays(7).AddHours(10), IsAllDay = false },
            };

            _joinRequests = new List<JoinRequest>
            {
                new() { RequestId = "jr-001", ClassId = "class-002", StudentId = "student-006", Status = "Pending", RequestedAt = DateTime.UtcNow.AddHours(-3) },
                new() { RequestId = "jr-002", ClassId = "class-003", StudentId = "student-004", Status = "Pending", RequestedAt = DateTime.UtcNow.AddHours(-5) },
            };

            foreach (var c in _classes)
            {
                c.Instructor = _users.FirstOrDefault(u => u.Id == c.InstructorId);
                c.Assignments = _assignments.Where(a => a.ClassId == c.ClassId).ToList();
                c.Announcements = _announcements.Where(a => a.ClassId == c.ClassId).ToList();
                c.Folders = _folders.Where(f => f.ClassId == c.ClassId).ToList();
                c.Members = _members.Where(m => m.ClassId == c.ClassId).ToList();
            }

            foreach (var ann in _announcements)
            {
                ann.Author = _users.FirstOrDefault(u => u.Id == ann.AnnouncementAuthorId);
                ann.Class = _classes.FirstOrDefault(c => c.ClassId == ann.ClassId);
            }

            foreach (var m in _members)
            {
                m.User = _users.FirstOrDefault(u => u.Id == m.UserId);
                m.Class = _classes.FirstOrDefault(c => c.ClassId == m.ClassId);
            }

            foreach (var sub in _submissions)
            {
                sub.Student = _users.FirstOrDefault(u => u.Id == sub.StudentId);
                sub.Assignment = _assignments.FirstOrDefault(a => a.AssignmentId == sub.AssignmentId);
            }

            foreach (var att in _attendance)
            {
                att.Student = _users.FirstOrDefault(u => u.Id == att.StudentId);
                att.Class = _classes.FirstOrDefault(c => c.ClassId == att.ClassId);
            }

            foreach (var jr in _joinRequests)
            {
                jr.Student = _users.FirstOrDefault(u => u.Id == jr.StudentId);
                jr.Class = _classes.FirstOrDefault(c => c.ClassId == jr.ClassId);
            }
        }

        public string GetGradientForClass(string classId)
        {
            var index = Math.Abs(classId.GetHashCode()) % GradientPresets.Count;
            return GradientPresets[index];
        }

        public Task<User?> GetCurrentUserAsync() => Task.FromResult(_users.FirstOrDefault(u => u.Id == _currentTeacherId));
        public Task<List<Class>> GetTeacherClassesAsync(string teacherId) => Task.FromResult(_classes.Where(c => c.InstructorId == teacherId).ToList());
        public Task<Class?> GetClassAsync(string classId) => Task.FromResult(_classes.FirstOrDefault(c => c.ClassId == classId));

        public Task<Class> CreateClassAsync(Class newClass)
        {
            newClass.ClassId = $"class-{_idCounter++}";
            newClass.InstructorId = _currentTeacherId;
            newClass.Instructor = _users.FirstOrDefault(u => u.Id == _currentTeacherId);
            newClass.CreatedAt = DateTime.UtcNow;
            _classes.Add(newClass);
            return Task.FromResult(newClass);
        }

        public Task<List<Assignment>> GetClassAssignmentsAsync(string classId) => Task.FromResult(_assignments.Where(a => a.ClassId == classId).ToList());
        public Task<Assignment?> GetAssignmentAsync(string assignmentId) => Task.FromResult(_assignments.FirstOrDefault(a => a.AssignmentId == assignmentId));
        public Task<List<Submission>> GetAssignmentSubmissionsAsync(string assignmentId) => Task.FromResult(_submissions.Where(s => s.AssignmentId == assignmentId).ToList());

        public Task SaveGradeAsync(string submissionId, double? score)
        {
            var sub = _submissions.FirstOrDefault(s => s.SubmissionId == submissionId);
            if (sub != null) sub.Score = score;
            return Task.CompletedTask;
        }

        public Task<List<Member>> GetClassMembersAsync(string classId) => Task.FromResult(_members.Where(m => m.ClassId == classId).ToList());
        public Task<List<JoinRequest>> GetPendingJoinRequestsAsync(string classId) => Task.FromResult(_joinRequests.Where(j => j.ClassId == classId && j.Status == "Pending").ToList());

        public Task AcceptJoinRequestAsync(string requestId)
        {
            var jr = _joinRequests.FirstOrDefault(j => j.RequestId == requestId);
            if (jr != null)
            {
                jr.Status = "Accepted";
                jr.ResolvedAt = DateTime.UtcNow;
                var newMember = new Member { MemberId = $"m-{_idCounter++}", UserId = jr.StudentId, ClassId = jr.ClassId, Role = "Student", JoinedDate = DateTime.UtcNow };
                newMember.User = _users.FirstOrDefault(u => u.Id == jr.StudentId);
                newMember.Class = _classes.FirstOrDefault(c => c.ClassId == jr.ClassId);
                _members.Add(newMember);
            }
            return Task.CompletedTask;
        }

        public Task RejectJoinRequestAsync(string requestId)
        {
            var jr = _joinRequests.FirstOrDefault(j => j.RequestId == requestId);
            if (jr != null) { jr.Status = "Rejected"; jr.ResolvedAt = DateTime.UtcNow; }
            return Task.CompletedTask;
        }

        public Task RemoveMemberAsync(string memberId)
        {
            var m = _members.FirstOrDefault(x => x.MemberId == memberId);
            if (m != null) _members.Remove(m);
            return Task.CompletedTask;
        }

        public Task<List<Announcement>> GetClassAnnouncementsAsync(string classId) => Task.FromResult(_announcements.Where(a => a.ClassId == classId).OrderByDescending(a => a.AnnouncementDate).ToList());

        public Task<Announcement> PostAnnouncementAsync(Announcement announcement)
        {
            announcement.AnnouncementId = $"ann-{_idCounter++}";
            announcement.AnnouncementDate = DateTime.UtcNow;
            announcement.CreatedAt = DateTime.UtcNow;
            announcement.Author = _users.FirstOrDefault(u => u.Id == announcement.AnnouncementAuthorId);
            _announcements.Add(announcement);
            return Task.FromResult(announcement);
        }

        public Task<List<Folder>> GetClassFoldersAsync(string classId) => Task.FromResult(_folders.Where(f => f.ClassId == classId).ToList());
        public Task<List<AttendanceRecord>> GetAttendanceForDateAsync(string classId, DateTime date) => Task.FromResult(_attendance.Where(a => a.ClassId == classId && a.Date.Date == date.Date).ToList());

        public Task SaveAttendanceAsync(AttendanceRecord record)
        {
            var existing = _attendance.FirstOrDefault(a => a.ClassId == record.ClassId && a.StudentId == record.StudentId && a.Date.Date == record.Date.Date);
            if (existing != null) { existing.Status = record.Status; existing.UpdatedAt = DateTime.UtcNow; }
            else { record.AttendanceId = $"att-{_idCounter++}"; record.CreatedAt = DateTime.UtcNow; _attendance.Add(record); }
            return Task.CompletedTask;
        }

        public async Task MarkAllPresentAsync(string classId, DateTime date)
        {
            var students = _members.Where(m => m.ClassId == classId && m.Role == "Student").ToList();
            foreach (var s in students)
                await SaveAttendanceAsync(new AttendanceRecord { ClassId = classId, StudentId = s.UserId, Date = date, Status = "Present" });
        }

        public Task<List<Conversation>> GetConversationsAsync(string userId) => Task.FromResult(_conversations.OrderByDescending(c => c.UpdatedAt).ToList());
        public Task<List<Message>> GetMessagesAsync(string conversationId) => Task.FromResult(_messages.Where(m => m.ConversationId == conversationId).OrderBy(m => m.SentAt).ToList());

        public Task SendMessageAsync(string conversationId, string senderId, string content)
        {
            var msg = new Message { MessageId = $"msg-{_idCounter++}", ConversationId = conversationId, SenderId = senderId, Content = content, SentAt = DateTime.UtcNow };
            _messages.Add(msg);
            var conv = _conversations.FirstOrDefault(c => c.ConversationId == conversationId);
            if (conv != null) { conv.LastMessage = msg; conv.UpdatedAt = DateTime.UtcNow; }
            return Task.CompletedTask;
        }

        public Task<List<ActivityItem>> GetActivitiesAsync(string userId, string? category = null)
        {
            var q = _activities.AsQueryable();
            if (!string.IsNullOrEmpty(category) && category != "All") q = q.Where(a => a.Category == category);
            return Task.FromResult(q.OrderByDescending(a => a.Timestamp).ToList());
        }

        public Task<List<CalendarEvent>> GetCalendarEventsAsync(string userId, DateTime month)
        {
            var start = new DateTime(month.Year, month.Month, 1);
            var end = start.AddMonths(1);
            return Task.FromResult(_calendarEvents.Where(e => e.StartDate >= start && e.StartDate < end).OrderBy(e => e.StartDate).ToList());
        }

        public Task<List<Submission>> GetRecentSubmissionsAsync(string teacherId, int count = 4)
        {
            var teacherClassIds = _classes.Where(c => c.InstructorId == teacherId).Select(c => c.ClassId).ToList();
            var assignmentIds = _assignments.Where(a => teacherClassIds.Contains(a.ClassId)).Select(a => a.AssignmentId).ToList();
            return Task.FromResult(_submissions.Where(s => assignmentIds.Contains(s.AssignmentId) && s.SubmittedAt != null).OrderByDescending(s => s.SubmittedAt).Take(count).ToList());
        }
    }
}
