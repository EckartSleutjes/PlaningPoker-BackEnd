using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;
using System.Numerics;

namespace PlaningPoker.Application.Service
{
    public class StorieService(IStorieRepository _storieRepository) : IStorieService
    {
        public async Task<bool> CreateStorie(StorieDto storie)
        {
            try
            {
                if (await RoomHasStorieNotPlayed(storie.RoomId))
                {
                    Console.WriteLine($"Error in CreateStorie => RoomHasStorieNotPlayed");
                    return false;
                }                    
                await _storieRepository.CreateStorie((Storie) storie);
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
