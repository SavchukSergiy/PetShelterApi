using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using PetShelterApi.Dtos.userDto;
using PetShelterApi.Models;
using PetShelterApi.Repositories.UserRepository;
using PetShelterApi.Services.Users;

namespace PetShelterApi.Tests.Services.UserTests;

public class UserServiceTest
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserServiceTest()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserRegisterDto, User>();
            cfg.CreateMap<User, UserRegisterDto>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task AddUser_ShouldCallRepositoryAddAsync()
    {
        // Arrange
        var userService = new UserService(_userRepositoryMock.Object, _mapper, _logger);
        var dto = new UserRegisterDto
        {
            Username = "test",
            Password = "123",
            Role = "User"
        };

        // Act
        await userService.AddUser(dto);

        // Assert
        _userRepositoryMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
    }
}
