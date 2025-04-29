using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PetShelterApi.Data;
using PetShelterApi.Dtos.userDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PetShelterApi.Tests.IntegrationTests.Auth
{
    public class AuthControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public AuthControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Register_ShouldReturnOk_WhenUserIsRegistered()
        {
            // Arrange: створюємо тестовий об'єкт для реєстрації
            var registerDto = new UserRegisterDto
            {
                Username = "testuser",
                Password = "TestPassword123",
                Role = "user"
            };

            // Act: викликаємо метод реєстрації через API
            var response = await _client.PostAsJsonAsync("/api/auth/register", registerDto);

            // Assert: перевіряємо, що відповідь має статус 200 OK
            response.EnsureSuccessStatusCode();

            // Додатково, можна перевірити, чи користувач був доданий до бази
            // Наприклад, перевіримо, чи є користувач в базі даних
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PetSHelterContext>();
                var user = await dbContext.Users
                    .FirstOrDefaultAsync(u => u.Username == "testuser");

                Assert.NotNull(user);
                Assert.Equal("testuser", user.Username);
            }
        }
    }
}
