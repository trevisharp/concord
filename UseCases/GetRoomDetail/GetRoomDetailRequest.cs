namespace Concord.UseCases.GetRoomDetail;

public record GetRoomDetailRequest(
    Guid ProfileId,
    Guid RoomId
);