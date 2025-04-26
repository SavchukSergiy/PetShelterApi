using PetShelterApi.Models;

namespace PetShelterApi.Services.Users
{
    public interface IUserService
    {
        void AddUser(User user);
        User? GetUserByUserName(string username);
    }
}
