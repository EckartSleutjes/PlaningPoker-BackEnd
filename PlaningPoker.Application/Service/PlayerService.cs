using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class PlayerService(IPlayerRepository _playerRepository, IRoomService _roomService) : IPlayerService
    {
        public async Task<bool> CreatePlayer(PlayerDto player)
        {
            try
            {
                var room = await _roomService.GetRoomByTag(player.TagRoom);
                if (room == null)
                    return false;
                var playerModel = (Player)player;
                playerModel.SetRoomId(room.Id);
                await _playerRepository.CreatePlayer(playerModel);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePlayer => {ex}");
                return false;
            }
        }

        public async Task<Player?> GetPlayerById(Guid playerId)
        {
            return await _playerRepository.GetPlayerById(playerId);
        }

        public async Task<List<Player>?> GetPlayersByRoomId(Guid roomId)
        {
            return await _playerRepository.GetPlayersByRoomId(roomId);
        }
    }
}
