using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IRoomService
    {
        Task<Room?> GetRoomByPlayerId (Guid playerId);
        Task<Room?> GetRoomById (Guid roomId);
        Task<Room?> GetRoomByTag (string tag);
        Task<CreateRoomResponseDto> CreateRoom (RoomDto room);
    }
}
