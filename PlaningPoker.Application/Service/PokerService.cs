using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class PokerService (IPokerRepository _pokerRepository) : IPokerService
    {
        public async Task<List<PokerItem>> GetPokerItemsByPokerId(Guid pokerId)
        {
            return await _pokerRepository.GetPokerItemsByPokerId(pokerId);
        }
    }
}
