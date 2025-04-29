using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PetShelterApi.Controllers;
using PetShelterApi.Dtos.userDto;
using PetShelterApi.Models;
using PetShelterApi.Services.Auth;
using PetShelterApi.Services.Users;
using Xunit;

namespace PetShelterApi.Tests.Controllers
{
    public class AuthControllerTest
    {
        [Fact]
        public async Task Register_ShouldReturnOk_WhenUserIsAdded()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            var mockJwt = new Mock<IJwtTokenGenerator>();
            var mockMapper = new Mock<IMapper>();

            var controller = new AuthController(mockService.Object, mockJwt.Object, mockMapper.Object);

            var registerDto = new UserRegisterDto
            {
                Username = "testuser",
                Password = "testpass"
            };

            // Act
            var result = await controller.Register(registerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User registered successfully.", okResult.Value);
        }
    }
}
