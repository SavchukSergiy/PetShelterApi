using PetShelterApi.Models;

namespace PetShelterApi.Services.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
