using PlaningPoker.Domain.Dto;

namespace PlaningPoker.Application.Contract
{
    public interface IAuthenticationService
    {
        Task<UserDto?> FindAsync(Guid id);
        Task<Guid?> AddAsync(AddOrUpdateUserDto user);
        Task<AddOrUpdateUserDto?> UpdateAsync(AddOrUpdateUserDto user, Guid id);
        Task<Guid?> DeleteAsync(Guid id);
        Task<string?> LoginAsync(LoginDto request);
    }
}
