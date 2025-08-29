namespace Concord.Entities;

public class Profile
{
    public Guid ID { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<Room> CreatedRooms { get; set; } = [];
    public ICollection<Member> Members { get; set; } = [];
}