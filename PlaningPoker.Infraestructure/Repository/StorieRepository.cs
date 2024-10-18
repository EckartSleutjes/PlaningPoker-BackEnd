using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class StorieRepository(PlaningPokerContext _db) : IStorieRepository
    {
        public async Task CreateStorie(Storie storie)
        {
            await _db.Storie.AddAsync(storie);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Storie>> GetStoriesByRoomId(Guid roomId, bool? played = null)
        {
            var dataSet = _db.Storie.Where(t => t.RoomId == roomId && (played == null || t.Played == played));
            return await dataSet.ToListAsync();
        }
    }
}
