using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EduConnect.SharedUI.Models;

namespace EduConnect.SharedUI.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetCurrentUserIdAsync();
        Task<string?> GetCurrentRoleAsync();
        Task<User?> GetCurrentUserAsync();
        Task<bool> SignInAsync(string email, string password);
        Task<bool> SignUpAsync(User user, string password);
        Task SignOutAsync();
        string DetectRole(string email);
    }

    // A client-side mock implementation. In production this calls EduConnect.Api.
    public class MockAuthService : IAuthService
    {
        private User? _currentUser;

        public Task<bool> IsAuthenticatedAsync() => Task.FromResult(_currentUser != null);
        public Task<string?> GetCurrentUserIdAsync() => Task.FromResult(_currentUser?.Id);
        public Task<string?> GetCurrentRoleAsync() => Task.FromResult(_currentUser?.Role);
        public Task<User?> GetCurrentUserAsync() => Task.FromResult(_currentUser);

        public string DetectRole(string email)
        {
            if (email.EndsWith("@deped.gov.ph", StringComparison.OrdinalIgnoreCase))
                return "Teacher";
            return "Student";
        }

        public Task<bool> SignInAsync(string email, string password)
        {
            // Hardcoded mock sign-in for demo
            if (email.EndsWith("@deped.gov.ph", StringComparison.OrdinalIgnoreCase))
            {
                _currentUser = new User
                {
                    Id = "teacher-001",
                    Name = "Maria Santos",
                    Email = email,
                    Role = "Teacher",
                    LearnerReferenceNumber = null,
                    LastLoginAt = DateTime.UtcNow
                };
            }
            else
            {
                _currentUser = new User
                {
                    Id = "student-001",
                    Name = "Juan Dela Cruz",
                    Email = email,
                    Role = "Student",
                    LearnerReferenceNumber = 123456789012L,
                    LastLoginAt = DateTime.UtcNow
                };
            }
            return Task.FromResult(true);
        }

        public Task<bool> SignUpAsync(User user, string password)
        {
            user.Role = DetectRole(user.Email);
            _currentUser = user;
            return Task.FromResult(true);
        }

        public Task SignOutAsync()
        {
            _currentUser = null;
            return Task.CompletedTask;
        }
    }
}
