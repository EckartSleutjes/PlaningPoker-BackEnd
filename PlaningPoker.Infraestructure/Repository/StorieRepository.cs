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
    }
}
