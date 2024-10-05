using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IRoomService
    {
        Task<Room?> GetRoomById (Guid roomId);
        Task<bool> CreateRoom (RoomDto room);
    }
}
