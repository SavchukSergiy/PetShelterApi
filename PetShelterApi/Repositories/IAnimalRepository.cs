using PetShelterApi.Models;

namespace PetShelterApi.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal?> GetByIdAsync(int id);
        Task AddAsync(Animal animal);
        Task DeleteAsync(Animal animal);
        Task SaveChangesAsync();
    }
}
