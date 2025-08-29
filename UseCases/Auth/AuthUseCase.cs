using Concord.Entities;
using Concord.Models;
using Concord.Services.JWT;

using Microsoft.EntityFrameworkCore;

namespace Concord.UseCases.Auth;

public class AuthUseCase(
    ConcordDbContext ctx,
    IJWTService jwt
)
{
    public async Task<Result<AuthResponse>> ExecuteAsync(AuthRequest request)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(
            p => p.Username == request.Login || p.Email == request.Login
        );
        if (profile is null)
            return Result<AuthResponse>.Fail("Missing Profile");
        
        if (profile.Password != request.Password)
            return Result<AuthResponse>.Fail("Wrong Password");
        
        var token = jwt.CreateToken(new ProfileToAuth {
            Email = profile.Email,
            ID = profile.ID,
            Username = profile.Username
        });

        var response = new AuthResponse(token);
        return Result<AuthResponse>.Success(response);
    }
}