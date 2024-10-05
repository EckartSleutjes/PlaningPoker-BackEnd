using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IPlayerRepository
    {
        Task<Player?> GetPlayerById(Guid playerId);
        Task<List<Player>?> GetPlayersByRoomId(Guid roomId);
        Task CreatePlayer(Player player);
    }
}
