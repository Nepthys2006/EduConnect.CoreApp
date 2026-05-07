using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services;

public interface IAuthService
{
    AppUser? CurrentUser { get; }
    bool IsAuthenticated { get; }
    Task<bool> LoginAsync(string email, string password);
    Task RegisterAsync(string email, string password, string lastName, string firstName, string middleName, string? lrn);
    Task LogoutAsync();
    UserRole ResolveRole(string email);
    event Action? OnAuthStateChanged;
}
