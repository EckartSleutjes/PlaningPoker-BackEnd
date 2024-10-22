using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class PlayerService(IPlayerRepository _playerRepository, IRoomRepository _roomRepository) : IPlayerService
    {
        public async Task<Guid> CreatePlayer(PlayerDto player)
        {
            try
            {
                var room = await _roomRepository.GetRoomByTag(player.TagRoom);
                if (room == null)
                    return Guid.Empty;
                var playerModel = (Player)player;
                playerModel.SetRoomId(room.Id);
                await _playerRepository.CreatePlayer(playerModel);
                return playerModel.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePlayer => {ex}");
                return Guid.Empty;
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
                    CurrentStorieId = item.StoriePlayers.FirstOrDefault(t => !t.Storie.Played)?.StorieId,
                    PokerItemSelected = item.StoriePlayers.FirstOrDefault(t => !t.Storie.Played)?.PokerItem,
                    CurrentStoriePlayed = !string.IsNullOrWhiteSpace(item.StoriePlayers.FirstOrDefault(t => !t.Storie.Played)?.PokerItem)
                };
            }
        }
    }
}
