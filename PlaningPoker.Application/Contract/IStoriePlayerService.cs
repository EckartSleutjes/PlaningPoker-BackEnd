using PlaningPoker.Domain.Dto;

namespace PlaningPoker.Application.Contract
{
    public interface IStoriePlayerService
    {
        Task<bool> CreateStoriePlayer(StoriePlayerDto storiePlayerDto);
    }
}
