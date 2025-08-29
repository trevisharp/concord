namespace Concord.UseCases.CreateProfile;

public class CreateProfileUseCase
{
    public async Task<Result<CreateProfileResponse>> ExecuteAsync(CreateProfileRequest request)
    {
        return Result<CreateProfileResponse>.Fail("Não implementado.");
    }
}