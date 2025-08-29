namespace Concord.Entities;

public class Permition
{
    public Guid ID { get; set; }
    public required string Title { get; set; }

    public ICollection<Role> Roles { get; set; } = [];
}