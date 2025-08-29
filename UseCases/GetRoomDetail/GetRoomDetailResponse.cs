using Concord.Models;

namespace Concord.UseCases.GetRoomDetail;

public record GetRoomDetailResponse(
    string Title,
    string Creator,
    List<MemberData> Members
);