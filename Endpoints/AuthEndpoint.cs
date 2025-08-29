using Concord.Payloads;
using Concord.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Concord.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/auth", async (
            [FromServices]AuthUseCase useCase,
            [FromBody]AuthPayload payload) =>
        {
            var response = await useCase.ExecuteAsync(new AuthRequest(
                payload.Login,
                payload.Password
            ));
            
            if (response.IsSuccessfull)
                return Results.Ok(response.Value);
            
            return Results.Unauthorized();
        });
    }
}