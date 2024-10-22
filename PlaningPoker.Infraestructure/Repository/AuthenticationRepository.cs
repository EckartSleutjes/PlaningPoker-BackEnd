using Microsoft.EntityFrameworkCore;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure.Repository
{
    public class AuthenticationRepository(PlaningPokerContext _db) : IAuthenticationRepository
    {
        public async Task<User?> FindByIdAsync(Guid id)
        {
            return await _db.User.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User?> FindByUsernameAsync(string username)
        {
            return await _db.User.FirstOrDefaultAsync(e => e.Name == username);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _db.User.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _db.User.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _db.User.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}
