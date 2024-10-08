using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IStorieRepository
    {
        Task CreateStorie(Storie storie);
    }
}
