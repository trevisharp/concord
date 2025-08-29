namespace Concord.Entities;

public class Member
{
    public Guid ID { get; set; }
    
    public Guid ProfileId { get; set; }
    public Guid RoomId { get; set; }
    public Guid RoleId { get; set; }

    public Profile? Profile { get; set; }
    public Room? Room { get; set; }
    public Role? Role { get; set; }
}