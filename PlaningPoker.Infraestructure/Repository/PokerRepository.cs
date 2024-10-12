using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class PokerRepository (PlaningPokerContext _db) : IPokerRepository
    {
        public async Task CreatePoker(Poker poker)
        {
            await _db.Poker.AddAsync(poker);
            await _db.PokerItem.AddRangeAsync(poker.PokerItems);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PokerItem>> GetPokerItemsByPokerId(Guid pokerId)
        {
            return await _db.PokerItem.Where(t => t.PokerId == pokerId).ToListAsync();
        }
    }
}
