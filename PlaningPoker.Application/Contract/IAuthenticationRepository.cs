using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IAuthenticationRepository
    {
        Task<User?> FindByIdAsync(Guid id);
        Task<User?> FindByUsernameAsync(string username);
        Task<User?> FindByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
