using Concord.Entities;
using Concord.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Concord.UseCases.GetRoomDetail;

public class GetRoomDetailUseCase(ConcordDbContext ctx)
{   
    public async Task<Result<GetRoomDetailResponse>> ExecuteAsync(GetRoomDetailRequest request)
    {
        var room = await ctx.Rooms
            .Include(r => r.Creator)
            .Include(r => r.Members)
                .ThenInclude(m => m.Profile)
            .Include(r => r.Members)
                .ThenInclude(m => m.Role)
            .FirstOrDefaultAsync(r => r.ID == request.RoomId);
        if (room is null)
            return Result<GetRoomDetailResponse>.Fail("Missing Room");
        
        var isMember = room.Members
            .Any(m => m.ProfileId == request.ProfileId);
        if (!isMember)
            return Result<GetRoomDetailResponse>.Fail("Forbiden");

        // List<MemberData> members = [];
        // foreach (var member in room.Members)
        //     members.Add(new MemberData {
        //         ProfileName = member.Profile.Username,
        //         RoleName = member.Role.Title
        //     });
        
        var response = new GetRoomDetailResponse(
            room.Name,
            room.Creator.Username,
            [.. // Ou .ToList()
                room.Members.Select(m => new MemberData {
                    ProfileName = m.Profile.Username,
                    RoleName = m.Role.Title
                })
            ]
        );

        return Result<GetRoomDetailResponse>.Success(response);
    }
}