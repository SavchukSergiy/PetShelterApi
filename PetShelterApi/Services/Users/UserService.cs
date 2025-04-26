using PetShelterApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShelterApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByUserName(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
