using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class RoomRepository (PlaningPokerContext _db) : IRoomRepository
    {
        public async Task CreateRoom(Room room)
        {
            await _db.Room.AddAsync(room);
            await _db.SaveChangesAsync();
        }

        public async Task<Room?> GetRoomById(Guid roomId)
        {
            return await _db.Room.FindAsync(roomId);
        }

        public async Task<Room?> GetRoomByTag(string tag)
        {
            return await _db.Room.FirstOrDefaultAsync(t => t.Tag == tag);
        }
    }
}
