using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IStoriePlayerRepository
    {
        Task CreateStoriePlayer(StoriePlayer storiePlayer);
        Task<List<StoriePlayer>> GetStoriePlayersByStorie(Guid storieId);
        Task FlipCardInStorie(Guid storiePlayerId);
    }
}
