using Microsoft.EntityFrameworkCore;
using PetShelterApi.Data;
using PetShelterApi.Models;
using PetShelterApi.Repositories;
using PetShelterApi.Repositories.UserRepository;
using Xunit;

namespace PetShelterApi.Tests.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task GetByNameAsync_ShouldReturnUser_WhenExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PetSHelterContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new PetSHelterContext(options);
            var user = new User { Username = "john", Password = "123", Role = "User" };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var repo = new UserRepository(context);

            // Act
            var result = await repo.GetByNameAsync("john");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("john", result?.Username);
        }
    }
}
