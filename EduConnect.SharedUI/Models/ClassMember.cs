namespace EduConnect.SharedUI.Models;

public class ClassMember
{
    public Guid UserId { get; set; }
    public Guid ClassRoomId { get; set; }
    public MemberStatus Status { get; set; }
}
