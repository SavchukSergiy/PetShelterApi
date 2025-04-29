using Microsoft.EntityFrameworkCore;
using PetShelterApi.Models;

namespace PetShelterApi.Data
{
    public class PetSHelterContext : DbContext
    {
        public PetSHelterContext(DbContextOptions<PetSHelterContext> options)
            : base(options)
        {}

        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
