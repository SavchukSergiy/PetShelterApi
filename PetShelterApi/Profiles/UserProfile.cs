using AutoMapper;
using PetShelterApi.Models;
using PetShelterApi.Dtos.userDto;

namespace PetShelterApi.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}
