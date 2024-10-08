using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class StoriePlayerService(IStoriePlayerRepository _storiePlayerRepository, IRoomService _roomService) : IStoriePlayerService
    {
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateStoriePlayer => {ex}");
                return false;
            }
        }
    }
}
