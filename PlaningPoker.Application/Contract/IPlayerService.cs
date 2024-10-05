using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IPlayerService
    {
        Task<Player?> GetPlayerById (Guid playerId);
        Task<List<Player>?> GetPlayersByRoomId (Guid roomId);
        Task<bool> CreatePlayer (PlayerDto player);
    }
}
