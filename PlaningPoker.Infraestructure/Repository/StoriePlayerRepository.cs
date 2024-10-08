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
    }
}
