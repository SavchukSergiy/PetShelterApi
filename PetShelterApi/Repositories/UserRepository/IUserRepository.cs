using PetShelterApi.Models;

namespace PetShelterApi.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> GetByNameAsync(string name);
        Task AddAsync(User user);

        Task SaveChangesAsync();
    }
}
