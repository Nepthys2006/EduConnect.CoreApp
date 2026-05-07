namespace EduConnect.SharedUI.Models;

public class ContentItem
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
    public string? StoragePath { get; set; }

    public string FileSizeDisplay =>
        FileSizeBytes switch
        {
            < 1024 => $"{FileSizeBytes} B",
            < 1048576 => $"{FileSizeBytes / 1024.0:F1} KB",
            _ => $"{FileSizeBytes / 1048576.0:F1} MB"
        };
}
