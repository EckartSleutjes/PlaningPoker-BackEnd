using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class StoriePlayerRepository(PlaningPokerContext _db) : IStoriePlayerRepository
    {
        public async Task CreateStoriePlayer(StoriePlayer storiePlayer)
        {
            await _db.StoriePlayer.AddAsync(storiePlayer);
            await _db.SaveChangesAsync();
        }

        public async Task FlipCardInStorie(Guid storiePlayerId)
        {
            await _db.StoriePlayer.Where(t => t.Id == storiePlayerId).ExecuteUpdateAsync(t => t.SetProperty(t => t.Flip, true));
        }

        public async Task<List<StoriePlayer>> GetStoriePlayersByStorie(Guid storieId)
        {
            return await _db.StoriePlayer.Where(t => t.StorieId == storieId).ToListAsync();
        }
    }
}
