using PetShelterApi.Dtos;

namespace PetShelterApi.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalReadDto>> GetAllAnimalsAsync();
        Task<AnimalReadDto?> GetAnimalByIdAsync(int id);
        Task<AnimalReadDto> CreateAnimalAsync(AnimalCreateDto createDto);
        Task<bool> UpdateAnimalAsync(int id, AnimalUpdateDto updateDto);
        Task<bool> DeleteAnimalAsync(int id);
    }
}
