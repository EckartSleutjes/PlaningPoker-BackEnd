using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class RoomService (IRoomRepository _roomRepository) : IRoomService
    {
        public async Task<bool> CreateRoom(RoomDto room)
        {
            try
            {
                await _roomRepository.CreateRoom((Room)room);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateRoom => {ex}");
                return false;
            }
        }

        public async Task<Room?> GetRoomById(Guid roomId)
        {
            return await _roomRepository.GetRoomById(roomId);
        }
    }
}
