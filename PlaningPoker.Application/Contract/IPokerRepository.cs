using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IPokerRepository
    {
        Task<List<PokerItem>> GetPokerItemsByPokerId(Guid pokerId);
        Task CreatePoker(Poker poker);
    }
}
