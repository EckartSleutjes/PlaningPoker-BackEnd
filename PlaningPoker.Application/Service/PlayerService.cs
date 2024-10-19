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

        public IEnumerable<PlayerListDto> GetPlayersByRoomId(Guid roomId)
        {
            var players = _playerRepository.GetPlayersByRoomId(roomId).GetAwaiter().GetResult();
            foreach (var item in players ?? [])
            {
                yield return new PlayerListDto
                {
                    Name = item.Name,
                    PokerItemSelected = item.StoriePlayers.Where(t => !t.Storie.Played).FirstOrDefault()?.PokerItem,
                    CurrentStoriePlayed = !string.IsNullOrWhiteSpace(item.StoriePlayers.Where(t => !t.Storie.Played).FirstOrDefault()?.PokerItem)
                };
            }
        }
    }
}
