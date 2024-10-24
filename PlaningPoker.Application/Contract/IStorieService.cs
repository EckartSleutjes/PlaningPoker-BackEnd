using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IStorieService
    {
        Task<bool> CreateStorie(StorieDto storie, Guid? userId = null);
        Task<List<Storie>> GetStoriesByRoomId(Guid roomId, bool? played = null);
        Task PlayedStorie(Guid storieId);
        Task<Storie?> GetStorieById(Guid storieId);
    }
}
