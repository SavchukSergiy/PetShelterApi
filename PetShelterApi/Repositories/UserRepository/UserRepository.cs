using Microsoft.EntityFrameworkCore;
using PetShelterApi.Data;
using PetShelterApi.Models;

namespace PetShelterApi.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly PetSHelterContext _context;

        public UserRepository(PetSHelterContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user); 
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
