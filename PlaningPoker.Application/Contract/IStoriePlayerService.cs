using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IStoriePlayerService
    {
        Task<bool> CreateStoriePlayer(StoriePlayerDto storiePlayerDto);
        Task<List<StoriePlayer>> GetStoriePlayersByStorie(Guid storieId);
        Task<bool> FlipCardInStorie(Guid storiePlayerId);
    }
}
