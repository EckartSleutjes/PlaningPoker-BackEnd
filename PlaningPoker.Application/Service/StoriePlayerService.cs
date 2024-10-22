using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class StoriePlayerService(IStoriePlayerRepository _storiePlayerRepository, IRoomService _roomService, IPlayerService _playerService, IStorieService _storieService) : IStoriePlayerService
    {
        // TODO Create unit test for method
        public async Task<bool> CreateStoriePlayer(StoriePlayerDto storiePlayerDto)
        {
            try
            {
                var room = await _roomService.GetRoomByPlayerId(storiePlayerDto.PlayerId);
                if (room == null)
                {
                    Console.WriteLine($"Player wasn't in room.");
                    return false;
                }
                if ((room.PokerItems.Split(',').ToList().Find(t => t == storiePlayerDto.PokerItemSelected) == null))
                {
                    Console.WriteLine($"PokerItem not allowed.");
                    return false;
                }
                await _storiePlayerRepository.CreateStoriePlayer((StoriePlayer)storiePlayerDto);
                var players = _playerService.GetPlayersByRoomId(room.Id);
                if (players.All(t => t.CurrentStoriePlayed))
                    await _storieService.PlayedStorie(storiePlayerDto.StorieId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateStoriePlayer => {ex}");
                return false;
            }
        }
        // TODO Create unit test for method
        public async Task<List<StoriePlayer>> GetStoriePlayersByStorie(Guid storieId)
        {
            return await _storiePlayerRepository.GetStoriePlayersByStorie(storieId);
        }
        // TODO Create unit test for method
        public async Task<bool> FlipCardInStorie(Guid storiePlayerId)
        {
            try
            {
                await _storiePlayerRepository.FlipCardInStorie(storiePlayerId);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in FlipCardInStorie => {ex}");
                return false;
            }
        }
    }
}
