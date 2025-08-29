namespace Concord.UseCases.CreateProfile;

public record CreateProfileResponse(
    Guid ProfileID,
    string Token
);