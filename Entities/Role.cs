namespace Concord.Entities;

public class Role
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public Guid RoomId { get; set; }

    public ICollection<Permition> Permitions { get; set; } = [];
    public Room? Room { get; set; }
    public ICollection<Member> Members { get; set; } = [];
}