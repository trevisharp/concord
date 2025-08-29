namespace Concord.UseCases.CreateProfile;

public record CreateProfileRequest(
    string Username,
    string Email,
    string Password,
    string? ProfilePic
);