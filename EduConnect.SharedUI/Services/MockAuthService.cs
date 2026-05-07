using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services;

public class MockAuthService : IAuthService
{
    private readonly List<(AppUser User, string Password)> _users;

    public MockAuthService()
    {
        _users = new List<(AppUser, string)>
        {
            (new AppUser
            {
                Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"),
                FullName = "Prof. Alex",
                Email = "prof.alex@deped.gov.ph",
                Role = UserRole.Teacher,
                StaffId = "TCHR-2025-001",
                Gender = "Male",
                Birthday = new DateOnly(1985, 3, 15),
                EducationLevel = "Master's in Education",
                PhoneNumber = "+63 917 123 4567",
                MailingAddress = "123 Rizal St, Quezon City"
            }, "password123"),
            (new AppUser
            {
                Id = Guid.Parse("a2222222-2222-2222-2222-222222222222"),
                FullName = "Dr. Jane Smith",
                Email = "dr.janesmith@deped.gov.ph",
                Role = UserRole.Teacher,
                StaffId = "TCHR-2025-002",
                Gender = "Female",
                Birthday = new DateOnly(1980, 7, 22),
                EducationLevel = "PhD in Computer Science",
                PhoneNumber = "+63 918 234 5678"
            }, "password123"),
            (new AppUser
            {
                Id = Guid.Parse("b1111111-1111-1111-1111-111111111111"),
                FullName = "Marcus Aurelius",
                Email = "marcus.aurelius@gmail.com",
                Role = UserRole.Student,
                LRN = "123456789012"
            }, "password123"),
            (new AppUser
            {
                Id = Guid.Parse("b2222222-2222-2222-2222-222222222222"),
                FullName = "Sarah Jenkins",
                Email = "sarah.jenkins@gmail.com",
                Role = UserRole.Student,
                LRN = "123456789013"
            }, "password123"),
        };

        // Seed additional students
        var names = new[] {
            "Juan Dela Cruz", "Maria Santos", "Jose Rizal Jr.",
            "Ana Garcia", "Carlos Reyes", "Isabella Cruz",
            "Miguel Torres", "Sofia Mendoza", "Rafael Aquino",
            "Gabriela Silva", "Antonio Flores", "Elena Navarro",
            "Diego Castillo", "Camila Ramos", "Eduardo Bautista",
            "Victoria Gonzales", "Fernando Luna", "Patricia Villanueva",
            "Ricardo Fernandez", "Lucia Morales", "Andres Santiago",
            "Carmen Pascual", "Roberto Aguilar", "Teresa Mercado",
            "Manuel Ignacio", "Rosario Evangelista", "Alfredo Domingo",
            "Esperanza Salazar", "Bernardo Ocampo", "Gloria Manalo",
            "Pedro Valdez", "Josefina Palma", "Leonardo Abella",
            "Beatriz Soriano", "Ernesto Cruz", "Corazon Magno",
            "Francisco Lim", "Dolores Tan"
        };
        for (int i = 0; i < names.Length; i++)
        {
            var firstName = names[i].Split(' ')[0].ToLower();
            _users.Add((new AppUser
            {
                Id = Guid.NewGuid(),
                FullName = names[i],
                Email = $"{firstName}.student{i + 1}@gmail.com",
                Role = UserRole.Student,
                LRN = $"{200000000000 + i}"
            }, "password123"));
        }
    }

    public AppUser? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;
    public event Action? OnAuthStateChanged;

    public Task<bool> LoginAsync(string email, string password)
    {
        var match = _users.FirstOrDefault(u =>
            u.User.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);

        if (match.User != null)
        {
            CurrentUser = match.User;
            OnAuthStateChanged?.Invoke();
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task RegisterAsync(string email, string password, string lastName, string firstName, string middleName, string? lrn)
    {
        var role = ResolveRole(email);
        var user = new AppUser
        {
            Id = Guid.NewGuid(),
            FullName = $"{firstName} {lastName}",
            Email = email,
            Role = role,
            LRN = lrn
        };
        _users.Add((user, password));
        CurrentUser = user;
        OnAuthStateChanged?.Invoke();
        return Task.CompletedTask;
    }

    public Task LogoutAsync()
    {
        CurrentUser = null;
        OnAuthStateChanged?.Invoke();
        return Task.CompletedTask;
    }

    public UserRole ResolveRole(string email)
    {
        if (email.EndsWith("@deped.gov.ph", StringComparison.OrdinalIgnoreCase))
            return UserRole.Teacher;
        if (email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            return UserRole.Student;
        throw new InvalidOperationException("Unauthorized email domain.");
    }

    public List<AppUser> GetAllUsers() => _users.Select(u => u.User).ToList();
}
