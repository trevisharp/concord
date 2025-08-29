using System.Security.Claims;
using Concord.UseCases.GetRoomDetail;
using Microsoft.AspNetCore.Mvc;

namespace Concord.Endpoints;

public static class RoomEndpoint
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapGet("/room/{roomId}", async (Guid roomId,
            HttpContext http,
            [FromServices]GetRoomDetailUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return Results.Unauthorized();
            
            var userId = Guid.Parse(claim.Value);
            var response = await useCase.ExecuteAsync(new(userId, roomId));

            return Results.Ok(response);
        }).RequireAuthorization();
    }
}