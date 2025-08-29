namespace Concord.Entities;

public class Room
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public Guid CreatorId { get; set; }

    public Profile? Creator { get; set; }
    public ICollection<Role> Roles { get; set; } = [];
    public ICollection<Member> Members { get; set; } = [];
}