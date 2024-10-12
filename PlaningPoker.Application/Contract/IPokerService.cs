using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IPokerService
    {
        Task<List<PokerItem>> GetPokerItemsByPokerId(Guid pokerId);
        Task<bool> CreatePoker(PokerDto dto);
    }
}
