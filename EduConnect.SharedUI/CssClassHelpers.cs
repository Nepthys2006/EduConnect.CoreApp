using System;

namespace EduConnect.SharedUI
{
    public static class CssClassHelpers
    {
        public static string GetGradientClass(string classId)
        {
            var index = Math.Abs(classId.GetHashCode()) % 6;
            return $"ec-gradient-{index + 1}";
        }

        public static string GetStatusBadgeClass(string status)
        {
            return status?.ToLower() switch
            {
                "present" or "submitted" or "accepted" or "active" or "ongoing" => "ec-badge-success",
                "absent" or "rejected" or "deleted" => "ec-badge-danger",
                "late" or "pending" or "draft" => "ec-badge-warning",
                "excused" or "inactive" => "ec-badge-neutral",
                _ => "ec-badge-neutral"
            };
        }

        public static string GetRoleBadgeClass(string role)
        {
            return role?.ToLower() switch
            {
                "teacher" or "professor" => "ec-badge-primary",
                _ => "ec-badge-neutral"
            };
        }

        public static string GetInitials(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "?";
            var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0][0].ToString().ToUpperInvariant();
            return $"{parts[0][0]}{parts[^1][0]}".ToUpperInvariant();
        }

        public static string GetDueBadgeClass(DateTime dueDate)
        {
            var diff = dueDate.Date - DateTime.UtcNow.Date;
            if (diff.TotalDays < 0) return "ec-badge-danger";
            if (diff.TotalDays == 0) return "ec-badge-danger";
            if (diff.TotalDays == 1) return "ec-badge-warning";
            return "ec-badge-neutral";
        }

        public static string GetDueBadgeText(DateTime dueDate)
        {
            var diff = dueDate.Date - DateTime.UtcNow.Date;
            if (diff.TotalDays == 0) return "Today";
            if (diff.TotalDays == 1) return "Tomorrow";
            return $"{diff.TotalDays:0} days";
        }
    }
}
