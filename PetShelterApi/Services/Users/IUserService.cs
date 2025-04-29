using Microsoft.AspNetCore.Mvc;
using PetShelterApi.Dtos.userDto;
using PetShelterApi.Models;

namespace PetShelterApi.Services.Users
{
    public interface IUserService
    {
        Task<UserRegisterDto> AddUser(UserRegisterDto createDto);
        Task<UserRegisterDto?> GetUserByUserName(string username);
    }
}
