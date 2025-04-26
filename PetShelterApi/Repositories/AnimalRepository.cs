using Microsoft.EntityFrameworkCore;
using PetShelterApi.Data;
using PetShelterApi.Models;

namespace PetShelterApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetSHelterContext _context;
        public AnimalRepository(PetSHelterContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Animal animal)
        {
            await _context.Animals.AddAsync(animal);
        }

        public async Task DeleteAsync(Animal animal)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<Animal?> GetByIdAsync(int id)
        {
            return await _context.Animals.FindAsync(id);
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
