using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IStoriePlayerRepository
    {
        Task CreateStoriePlayer(StoriePlayer storiePlayer);
    }
}
