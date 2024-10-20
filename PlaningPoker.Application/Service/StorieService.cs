using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class StorieService(IStorieRepository _storieRepository, IRoomService _roomService) : IStorieService
    {
        public async Task<bool> CreateStorie(StorieDto storie)
        {
            try
            {
                var room = await _roomService.GetRoomByTag(storie.TagRoom);
                if (room == null)
                {
                    Console.WriteLine($"Error in CreateStorie => GetRoomByTag");
                    return false;
                }
                if (await RoomHasStorieNotPlayed(room.Id))
                {
                    Console.WriteLine($"Error in CreateStorie => RoomHasStorieNotPlayed");
                    return false;
                }
                var storieModel = (Storie)storie;
                storieModel.SetRoomId(room.Id);
                await _storieRepository.CreateStorie(storieModel);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateStorie => {ex}");
                return false;
            }
        }

        public async Task<Storie?> GetStorieById(Guid storieId)
        {
            return await _storieRepository.GetStorieById(storieId);
        }

        public async Task<List<Storie>> GetStoriesByRoomId(Guid roomId, bool? played = null)
        {
            return await _storieRepository.GetStoriesByRoomId(roomId, played);
        }

        private async Task<bool> RoomHasStorieNotPlayed(Guid roomId)
        {
            var storiesNotPlayed = await GetStoriesByRoomId(roomId, false);
            return storiesNotPlayed.Count > 0;
        }
    }
}
