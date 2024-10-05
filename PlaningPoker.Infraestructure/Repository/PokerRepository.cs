using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class PokerRepository (PlaningPokerContext _db) : IPokerRepository
    {
        public async Task<List<PokerItem>> GetPokerItemsByPokerId(Guid pokerId)
        {
            return await _db.PokerItem.Where(t => t.PokerId == pokerId).ToListAsync();
        }
    }
}
