using Concord.Models;

namespace Concord.UseCases.GetRoomDetail;

public record GetRoomDetailResponse(
    string Title,
    string Creator,
    IEnumerable<MemberData> Members
);