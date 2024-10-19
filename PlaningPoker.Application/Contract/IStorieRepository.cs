using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IStorieRepository
    {
        Task CreateStorie(Storie storie);
        Task<List<Storie>> GetStoriesByRoomId(Guid roomId, bool? played = null);
        Task<Storie?> GetStorieById(Guid storieId);
    }
}
