using System.ComponentModel.DataAnnotations;

namespace Concord.Payloads;

public record AuthPayload
{
    [Required]
    [MaxLength(256)]
    public required string Login { get; init; }

    [Required]
    [MaxLength(256)]
    public required string Password { get; init; }
}