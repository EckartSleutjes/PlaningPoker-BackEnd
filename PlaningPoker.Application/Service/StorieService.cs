using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class StorieService(IStorieRepository _storieRepository) : IStorieService
    {
        public async Task<bool> CreateStorie(StorieDto storie)
        {
            try
            {
                await _storieRepository.CreateStorie((Storie) storie);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateStorie => {ex}");
                return false;
            }
        }
    }
}
