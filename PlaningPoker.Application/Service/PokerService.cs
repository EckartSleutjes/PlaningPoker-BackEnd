using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class PokerService (IPokerRepository _pokerRepository) : IPokerService
    {
        public async Task<bool> CreatePoker(PokerDto dto)
        {
            try
            {
                await _pokerRepository.CreatePoker((Poker)dto);
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePoker => {ex}");
                return false;
            }
        }

        public async Task<List<PokerItem>> GetPokerItemsByPokerId(Guid pokerId)
        {
            return await _pokerRepository.GetPokerItemsByPokerId(pokerId);
        }
    }
}
