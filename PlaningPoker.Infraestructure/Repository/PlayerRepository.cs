using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class PlayerRepository(PlaningPokerContext _db) : IPlayerRepository
    {
        public async Task CreatePlayer(Player player)
        {
            await _db.Player.AddAsync(player);
            await _db.SaveChangesAsync();
        }

        public async Task<Player?> GetPlayerById(Guid playerId)
        {
            return await _db.Player.FindAsync(playerId);
        }

        public async Task<List<Player>?> GetPlayersByRoomId(Guid roomId)
        {
            return await _db.Player.Where(t => t.RoomId == roomId).ToListAsync();
        }
    }
}
