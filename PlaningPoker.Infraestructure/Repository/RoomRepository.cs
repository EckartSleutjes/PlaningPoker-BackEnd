using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class RoomRepository (PlaningPokerContext _db) : IRoomRepository
    {
        public async Task CreateRoom(Room room)
        {
            await _db.Room.AddAsync(room);
        }

        public async Task<Room?> GetRoomById(Guid roomId)
        {
            return await _db.Room.FindAsync(roomId);
        }
    }
}
