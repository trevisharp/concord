namespace Concord.Models;

public record ProfileToAuth
{
    public required Guid ID { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}