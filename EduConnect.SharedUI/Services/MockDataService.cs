using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services;

public class MockDataService : IDataService
{
    private readonly MockAuthService _authService;
    private readonly List<ClassRoom> _classes = new();
    private readonly List<Assignment> _assignments = new();
    private readonly List<Submission> _submissions = new();
    private readonly List<Announcement> _announcements = new();
    private readonly List<ContentModule> _modules = new();
    private readonly List<AttendanceRecord> _attendance = new();
    private readonly List<Message> _messages = new();
    private readonly List<Conversation> _conversations = new();
    private readonly List<CalendarEvent> _events = new();
    private readonly List<ActivityItem> _activities = new();
    private readonly List<TodoItem> _todos = new();

    public MockDataService(IAuthService authService)
    {
        _authService = (MockAuthService)authService;
        SeedData();
    }

    private void SeedData()
    {
        var profAlex = Guid.Parse("a1111111-1111-1111-1111-111111111111");
        var drJane = Guid.Parse("a2222222-2222-2222-2222-222222222222");
        var marcus = Guid.Parse("b1111111-1111-1111-1111-111111111111");
        var sarah = Guid.Parse("b2222222-2222-2222-2222-222222222222");
        var allStudents = _authService.GetAllUsers().Where(u => u.Role == UserRole.Student).ToList();

        // Classes
        var csClass = new ClassRoom
        {
            Id = Guid.Parse("c1111111-1111-1111-1111-111111111111"),
            Subject = "Introduction to Computer Science",
            GradeLevel = "Grade 10",
            Section = "Einstein",
            SchoolYear = "2025-2026",
            TeacherId = drJane,
            GradientIndex = 0,
            StartTime = "08:00 AM",
            EndTime = "09:30 AM",
            Members = allStudents.Take(30).Select(s => new ClassMember
            {
                UserId = s.Id,
                ClassRoomId = Guid.Parse("c1111111-1111-1111-1111-111111111111"),
                Status = MemberStatus.Active
            }).ToList()
        };

        var physicsPlato = new ClassRoom
        {
            Id = Guid.Parse("c2222222-2222-2222-2222-222222222222"),
            Subject = "Intro to Particle Physics",
            GradeLevel = "Grade 9",
            Section = "Plato",
            SchoolYear = "2025-2026",
            TeacherId = profAlex,
            GradientIndex = 1,
            StartTime = "04:00 PM",
            EndTime = "05:30 PM",
            Members = allStudents.Skip(5).Take(28).Select(s => new ClassMember
            {
                UserId = s.Id,
                ClassRoomId = Guid.Parse("c2222222-2222-2222-2222-222222222222"),
                Status = MemberStatus.Active
            }).ToList()
        };

        var physicsEinstein = new ClassRoom
        {
            Id = Guid.Parse("c3333333-3333-3333-3333-333333333333"),
            Subject = "Intro to Particle Physics",
            GradeLevel = "Grade 10",
            Section = "Einstein",
            SchoolYear = "2025-2026",
            TeacherId = profAlex,
            GradientIndex = 2,
            StartTime = "04:00 PM",
            EndTime = "05:30 PM",
            Members = allStudents.Take(25).Select(s => new ClassMember
            {
                UserId = s.Id,
                ClassRoomId = Guid.Parse("c3333333-3333-3333-3333-333333333333"),
                Status = MemberStatus.Active
            }).ToList()
        };

        var physicsArchimedes = new ClassRoom
        {
            Id = Guid.Parse("c4444444-4444-4444-4444-444444444444"),
            Subject = "Intro to Particle Physics",
            GradeLevel = "Grade 9",
            Section = "Archimedes",
            SchoolYear = "2025-2026",
            TeacherId = profAlex,
            GradientIndex = 3,
            StartTime = "04:00 PM",
            EndTime = "05:30 PM",
            Members = allStudents.Skip(10).Take(26).Select(s => new ClassMember
            {
                UserId = s.Id,
                ClassRoomId = Guid.Parse("c4444444-4444-4444-4444-444444444444"),
                Status = MemberStatus.Active
            }).ToList()
        };

        // Add pending requests
        physicsEinstein.Members.Add(new ClassMember { UserId = allStudents.Last().Id, ClassRoomId = physicsEinstein.Id, Status = MemberStatus.Pending });
        csClass.Members.Add(new ClassMember { UserId = allStudents[^2].Id, ClassRoomId = csClass.Id, Status = MemberStatus.Pending });

        _classes.AddRange(new[] { csClass, physicsPlato, physicsEinstein, physicsArchimedes });

        // Assignments for CS class
        _assignments.AddRange(new[]
        {
            new Assignment { Id = Guid.NewGuid(), ClassRoomId = csClass.Id, Title = "Problem Set 1: C Basics", Description = "Complete exercises on variables, loops, and conditionals in C.", Type = AssignmentType.ProblemSet, DueDate = new DateTime(2025, 10, 15), MaxPoints = 100, Status = AssignmentStatus.Active },
            new Assignment { Id = Guid.NewGuid(), ClassRoomId = csClass.Id, Title = "Week 4 Quiz: Data Structures", Description = "Multiple choice and short answer on arrays, linked lists, and stacks.", Type = AssignmentType.Quiz, DueDate = new DateTime(2025, 10, 22), MaxPoints = 50, Status = AssignmentStatus.Active },
            new Assignment { Id = Guid.NewGuid(), ClassRoomId = csClass.Id, Title = "Research Paper: History of AI", Description = "A 2000-word paper on the evolution of artificial intelligence from Turing to modern transformers.", Type = AssignmentType.ResearchPaper, DueDate = new DateTime(2025, 10, 10), MaxPoints = 200, Status = AssignmentStatus.Active },
            new Assignment { Id = Guid.NewGuid(), ClassRoomId = csClass.Id, Title = "Problem Set 2: Memory Management", Description = "Exercises covering pointers, dynamic allocation, and memory leaks in C.", Type = AssignmentType.ProblemSet, DueDate = new DateTime(2025, 11, 1), MaxPoints = 150, Status = AssignmentStatus.Pending },
            new Assignment { Id = Guid.NewGuid(), ClassRoomId = csClass.Id, Title = "Midterm Preparation Quiz", Description = "Comprehensive review quiz covering Weeks 1-6 material.", Type = AssignmentType.Quiz, DueDate = new DateTime(2025, 11, 5), MaxPoints = 100, Status = AssignmentStatus.Pending },
        });

        // Submissions for first assignment
        var firstAssignment = _assignments[0];
        foreach (var member in csClass.Members.Where(m => m.Status == MemberStatus.Active).Take(24))
        {
            _submissions.Add(new Submission
            {
                Id = Guid.NewGuid(),
                AssignmentId = firstAssignment.Id,
                StudentId = member.UserId,
                SubmittedAt = firstAssignment.DueDate.AddDays(-Random.Shared.Next(0, 5)),
                IsLate = Random.Shared.NextDouble() < 0.1,
                Score = Random.Shared.Next(60, 101),
            });
        }

        // Announcements
        _announcements.AddRange(new[]
        {
            new Announcement
            {
                Id = Guid.NewGuid(), ClassRoomId = csClass.Id, AuthorId = drJane,
                Body = "Hello everyone! I've just uploaded the lecture slides for Module 3. Please review them before Thursday's sync session. We will be diving deep into Algorithmic Complexity.",
                PostedAt = DateTime.UtcNow.AddHours(-2),
                Attachments = new List<ContentItem>
                {
                    new() { Id = Guid.NewGuid(), FileName = "Week3_Complexity.pdf", FileType = "PDF", FileSizeBytes = 2516582 },
                    new() { Id = Guid.NewGuid(), FileName = "Lecture_Reference.png", FileType = "IMAGE", FileSizeBytes = 1153434 }
                }
            },
            new Announcement
            {
                Id = Guid.NewGuid(), ClassRoomId = csClass.Id, AuthorId = marcus,
                Body = "Has anyone started on the sorting algorithm implementation? I'm having a bit of trouble with the pivot selection in Quicksort.",
                PostedAt = DateTime.UtcNow.AddHours(-5),
            },
            new Announcement
            {
                Id = Guid.NewGuid(), ClassRoomId = csClass.Id, AuthorId = sarah,
                Body = "Reminder that our study group meets at 4 PM in the virtual lab! Link is in the Resources tab.",
                PostedAt = DateTime.UtcNow.AddDays(-1),
            },
        });

        // Content modules
        _modules.AddRange(new[]
        {
            new ContentModule
            {
                Id = Guid.NewGuid(), ClassRoomId = csClass.Id,
                Title = "Week 1 — Introduction to Computer Science",
                Description = "Overview of computing, binary systems, and the history of programming languages.",
                ItemCount = 12,
                Items = new List<ContentItem>
                {
                    new() { Id = Guid.NewGuid(), FileName = "Intro_Lecture.pdf", FileType = "PDF", FileSizeBytes = 3145728 },
                    new() { Id = Guid.NewGuid(), FileName = "Binary_Systems.pptx", FileType = "PPTX", FileSizeBytes = 5242880 },
                    new() { Id = Guid.NewGuid(), FileName = "History_Timeline.png", FileType = "IMAGE", FileSizeBytes = 1048576 },
                }
            },
            new ContentModule
            {
                Id = Guid.NewGuid(), ClassRoomId = csClass.Id,
                Title = "Week 2 — Variables and Data Types",
                Description = "Primitive types, type casting, and variable scope in C.",
                ItemCount = 8,
                Items = new List<ContentItem>
                {
                    new() { Id = Guid.NewGuid(), FileName = "DataTypes_Notes.pdf", FileType = "PDF", FileSizeBytes = 2097152 },
                    new() { Id = Guid.NewGuid(), FileName = "Practice_Exercises.pdf", FileType = "PDF", FileSizeBytes = 1572864 },
                }
            },
            new ContentModule
            {
                Id = Guid.NewGuid(), ClassRoomId = csClass.Id,
                Title = "Week 3 — Algorithmic Complexity",
                Description = "Big-O notation, time and space complexity analysis.",
                ItemCount = 6,
            },
        });

        // Attendance for June 2026
        var attendanceStudents = csClass.Members.Where(m => m.Status == MemberStatus.Active).Take(30).ToList();
        for (int day = 2; day <= 27; day++)
        {
            if (new DateOnly(2026, 6, day).DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) continue;
            foreach (var member in attendanceStudents)
            {
                var rand = Random.Shared.NextDouble();
                _attendance.Add(new AttendanceRecord
                {
                    Id = Guid.NewGuid(),
                    ClassRoomId = csClass.Id,
                    StudentId = member.UserId,
                    Date = new DateOnly(2026, 6, day),
                    Status = rand < 0.85 ? AttendanceStatus.Present : rand < 0.95 ? AttendanceStatus.Absent : AttendanceStatus.Excused
                });
            }
        }

        // Conversations
        _conversations.AddRange(new[]
        {
            new Conversation
            {
                Id = Guid.NewGuid(),
                ParticipantIds = new List<Guid> { drJane, marcus, sarah },
                ClassRoomId = csClass.Id,
                Title = "CS Study Group",
                IsGroup = true,
                LastMessageAt = DateTime.UtcNow.AddMinutes(-30),
                LastMessagePreview = "See you all at 4 PM!",
                UnreadCount = 2
            },
            new Conversation
            {
                Id = Guid.NewGuid(),
                ParticipantIds = new List<Guid> { drJane, marcus },
                Title = "Marcus Aurelius",
                IsGroup = false,
                LastMessageAt = DateTime.UtcNow.AddHours(-3),
                LastMessagePreview = "Thank you for the feedback, Dr. Smith.",
                UnreadCount = 0
            },
            new Conversation
            {
                Id = Guid.NewGuid(),
                ParticipantIds = new List<Guid> { profAlex, sarah },
                Title = "Sarah Jenkins",
                IsGroup = false,
                LastMessageAt = DateTime.UtcNow.AddDays(-1),
                LastMessagePreview = "I'll submit the revised report by Friday.",
                UnreadCount = 1
            },
        });

        // Messages for first conversation
        var studyGroupConv = _conversations[0];
        _messages.AddRange(new[]
        {
            new Message { Id = Guid.NewGuid(), SenderId = drJane, Body = "Hi everyone, I've created this group for our weekly study sessions.", SentAt = DateTime.UtcNow.AddDays(-2), IsGroupMessage = true, ClassRoomId = csClass.Id },
            new Message { Id = Guid.NewGuid(), SenderId = marcus, Body = "Great idea! Should we start with the sorting algorithms?", SentAt = DateTime.UtcNow.AddDays(-2).AddHours(1), IsGroupMessage = true, ClassRoomId = csClass.Id },
            new Message { Id = Guid.NewGuid(), SenderId = sarah, Body = "See you all at 4 PM!", SentAt = DateTime.UtcNow.AddMinutes(-30), IsGroupMessage = true, ClassRoomId = csClass.Id },
        });

        // Calendar events
        var today = DateTime.Today;
        _events.AddRange(new[]
        {
            new CalendarEvent { Id = Guid.NewGuid(), ClassRoomId = csClass.Id, Title = "CS Lecture", Start = today.AddHours(8), End = today.AddHours(9.5), Color = "#6366F1" },
            new CalendarEvent { Id = Guid.NewGuid(), ClassRoomId = physicsPlato.Id, Title = "Physics (Plato)", Start = today.AddHours(16), End = today.AddHours(17.5), Color = "#0EA5E9" },
            new CalendarEvent { Id = Guid.NewGuid(), ClassRoomId = physicsEinstein.Id, Title = "Physics (Einstein)", Start = today.AddDays(1).AddHours(16), End = today.AddDays(1).AddHours(17.5), Color = "#10B981" },
            new CalendarEvent { Id = Guid.NewGuid(), Title = "Problem Set 1 Due", Start = new DateTime(2025, 10, 15), End = new DateTime(2025, 10, 15), Color = "#DC2626", Category = "deadline" },
            new CalendarEvent { Id = Guid.NewGuid(), Title = "Quiz: Data Structures", Start = new DateTime(2025, 10, 22), End = new DateTime(2025, 10, 22), Color = "#D97706", Category = "deadline" },
        });

        // Activity feed
        _activities.AddRange(new[]
        {
            new ActivityItem { Id = Guid.NewGuid(), Title = "Marcus Aurelius submitted Problem Set 1", Category = "Submission", Timestamp = DateTime.UtcNow.AddHours(-1), IconType = "submission" },
            new ActivityItem { Id = Guid.NewGuid(), Title = "New message from Sarah Jenkins", Category = "Message", Timestamp = DateTime.UtcNow.AddHours(-2), IconType = "message" },
            new ActivityItem { Id = Guid.NewGuid(), Title = "Grade report generated for GR10-Einstein", Category = "Report", Timestamp = DateTime.UtcNow.AddHours(-5), IconType = "report" },
            new ActivityItem { Id = Guid.NewGuid(), Title = "Problem Set 2 deadline approaching", Category = "Alert", Timestamp = DateTime.UtcNow.AddHours(-8), IconType = "alert" },
            new ActivityItem { Id = Guid.NewGuid(), Title = "Sarah Jenkins submitted Research Paper", Category = "Submission", Timestamp = DateTime.UtcNow.AddDays(-1), IconType = "submission" },
            new ActivityItem { Id = Guid.NewGuid(), Title = "New join request for GR10-Einstein", Category = "Alert", Timestamp = DateTime.UtcNow.AddDays(-1), IconType = "alert" },
            new ActivityItem { Id = Guid.NewGuid(), Title = "Attendance recorded for June 15", Category = "Report", Timestamp = DateTime.UtcNow.AddDays(-2), IconType = "report" },
        });

        // Todos
        _todos.AddRange(new[]
        {
            new TodoItem { Id = Guid.NewGuid(), Title = "Grade Calculus HW #4", Description = "24/30 students submitted", DueDate = DateTime.Today, SubmittedCount = 24, TotalCount = 30 },
            new TodoItem { Id = Guid.NewGuid(), Title = "Review Lab Reports", Description = "12/28 students submitted", DueDate = DateTime.Today.AddDays(1), SubmittedCount = 12, TotalCount = 28 },
            new TodoItem { Id = Guid.NewGuid(), Title = "Check Problem Set 2", Description = "8/25 students submitted", DueDate = DateTime.Today.AddDays(3), SubmittedCount = 8, TotalCount = 25 },
        });
    }

    // Classes
    public Task<List<ClassRoom>> GetClassesAsync(Guid teacherId) =>
        Task.FromResult(_classes.Where(c => c.TeacherId == teacherId).ToList());

    public Task<ClassRoom?> GetClassByIdAsync(Guid classId) =>
        Task.FromResult(_classes.FirstOrDefault(c => c.Id == classId));

    public Task<ClassRoom> CreateClassAsync(ClassRoom classroom)
    {
        classroom.Id = Guid.NewGuid();
        classroom.GradientIndex = _classes.Count % 4;
        _classes.Add(classroom);
        return Task.FromResult(classroom);
    }

    // Assignments
    public Task<List<Assignment>> GetAssignmentsAsync(Guid classRoomId) =>
        Task.FromResult(_assignments.Where(a => a.ClassRoomId == classRoomId).ToList());

    public Task<Assignment> CreateAssignmentAsync(Assignment assignment)
    {
        assignment.Id = Guid.NewGuid();
        _assignments.Add(assignment);
        return Task.FromResult(assignment);
    }

    // Submissions
    public Task<List<Submission>> GetSubmissionsAsync(Guid assignmentId) =>
        Task.FromResult(_submissions.Where(s => s.AssignmentId == assignmentId).ToList());

    public Task UpdateScoreAsync(Guid submissionId, int score, string? feedback)
    {
        var sub = _submissions.FirstOrDefault(s => s.Id == submissionId);
        if (sub != null) { sub.Score = score; sub.Feedback = feedback; }
        return Task.CompletedTask;
    }

    // Members
    public Task<List<AppUser>> GetMembersAsync(Guid classRoomId)
    {
        var cls = _classes.FirstOrDefault(c => c.Id == classRoomId);
        if (cls == null) return Task.FromResult(new List<AppUser>());
        var activeIds = cls.Members.Where(m => m.Status == MemberStatus.Active).Select(m => m.UserId).ToHashSet();
        var allUsers = _authService.GetAllUsers();
        var teacher = allUsers.FirstOrDefault(u => u.Id == cls.TeacherId);
        var members = allUsers.Where(u => activeIds.Contains(u.Id)).ToList();
        if (teacher != null) members.Insert(0, teacher);
        return Task.FromResult(members);
    }

    public Task<List<ClassMember>> GetPendingRequestsAsync(Guid classRoomId)
    {
        var cls = _classes.FirstOrDefault(c => c.Id == classRoomId);
        return Task.FromResult(cls?.Members.Where(m => m.Status == MemberStatus.Pending).ToList() ?? new List<ClassMember>());
    }

    public Task AcceptMemberAsync(Guid classRoomId, Guid userId)
    {
        var cls = _classes.FirstOrDefault(c => c.Id == classRoomId);
        var member = cls?.Members.FirstOrDefault(m => m.UserId == userId);
        if (member != null) member.Status = MemberStatus.Active;
        return Task.CompletedTask;
    }

    public Task RejectMemberAsync(Guid classRoomId, Guid userId)
    {
        var cls = _classes.FirstOrDefault(c => c.Id == classRoomId);
        var member = cls?.Members.FirstOrDefault(m => m.UserId == userId);
        if (member != null) member.Status = MemberStatus.Rejected;
        return Task.CompletedTask;
    }

    // Announcements
    public Task<List<Announcement>> GetAnnouncementsAsync(Guid classRoomId) =>
        Task.FromResult(_announcements.Where(a => a.ClassRoomId == classRoomId).OrderByDescending(a => a.PostedAt).ToList());

    public Task<Announcement> PostAnnouncementAsync(Announcement announcement)
    {
        announcement.Id = Guid.NewGuid();
        announcement.PostedAt = DateTime.UtcNow;
        _announcements.Insert(0, announcement);
        return Task.FromResult(announcement);
    }

    // Content
    public Task<List<ContentModule>> GetModulesAsync(Guid classRoomId) =>
        Task.FromResult(_modules.Where(m => m.ClassRoomId == classRoomId).ToList());

    public Task<ContentModule> CreateModuleAsync(ContentModule module)
    {
        module.Id = Guid.NewGuid();
        _modules.Add(module);
        return Task.FromResult(module);
    }

    // Attendance
    public Task<List<AttendanceRecord>> GetAttendanceAsync(Guid classRoomId, DateOnly date) =>
        Task.FromResult(_attendance.Where(a => a.ClassRoomId == classRoomId && a.Date == date).ToList());

    public Task RecordAttendanceAsync(AttendanceRecord record)
    {
        var existing = _attendance.FirstOrDefault(a =>
            a.ClassRoomId == record.ClassRoomId && a.StudentId == record.StudentId && a.Date == record.Date);
        if (existing != null) existing.Status = record.Status;
        else { record.Id = Guid.NewGuid(); _attendance.Add(record); }
        return Task.CompletedTask;
    }

    public Task<List<DateOnly>> GetAttendanceDatesAsync(Guid classRoomId) =>
        Task.FromResult(_attendance.Where(a => a.ClassRoomId == classRoomId).Select(a => a.Date).Distinct().OrderByDescending(d => d).ToList());

    // Messages
    public Task<List<Conversation>> GetConversationsAsync(Guid userId) =>
        Task.FromResult(_conversations.Where(c => c.ParticipantIds.Contains(userId)).OrderByDescending(c => c.LastMessageAt).ToList());

    public Task<List<Message>> GetMessagesAsync(Guid conversationId) =>
        Task.FromResult(_messages.OrderBy(m => m.SentAt).ToList());

    public Task SendMessageAsync(Message message)
    {
        message.Id = Guid.NewGuid();
        message.SentAt = DateTime.UtcNow;
        _messages.Add(message);
        return Task.CompletedTask;
    }

    // Calendar
    public Task<List<CalendarEvent>> GetEventsAsync(Guid teacherId, int year, int month) =>
        Task.FromResult(_events.Where(e => e.Start.Year == year && e.Start.Month == month || e.End.Year == year && e.End.Month == month).ToList());

    // Activity
    public Task<List<ActivityItem>> GetActivityFeedAsync(Guid userId) =>
        Task.FromResult(_activities.OrderByDescending(a => a.Timestamp).ToList());

    // Dashboard
    public Task<List<TodoItem>> GetTodoItemsAsync(Guid teacherId) =>
        Task.FromResult(_todos);

    public Task<List<ClassRoom>> GetUpcomingClassesAsync(Guid teacherId) =>
        Task.FromResult(_classes.Where(c => c.TeacherId == teacherId).ToList());

    // Users
    public Task<AppUser?> GetUserByIdAsync(Guid userId) =>
        Task.FromResult(_authService.GetAllUsers().FirstOrDefault(u => u.Id == userId));

    public Task<List<AppUser>> GetAllStudentsAsync() =>
        Task.FromResult(_authService.GetAllUsers().Where(u => u.Role == UserRole.Student).ToList());

    public Task UpdateUserAsync(AppUser user)
    {
        // In mock, the user objects are references so they're already updated
        return Task.CompletedTask;
    }
}
