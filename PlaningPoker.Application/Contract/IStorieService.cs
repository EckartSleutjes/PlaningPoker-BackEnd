using PlaningPoker.Domain.Dto;

namespace PlaningPoker.Application.Contract
{
    public interface IStorieService
    {
        Task<bool> CreateStorie(StorieDto storie);
    }
}
