using AutoMapper;
using PetShelterApi.Dtos;
using PetShelterApi.Models;
using PetShelterApi.Repositories;
using Microsoft.Extensions.Logging;

namespace PetShelterApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AnimalService> _logger;

        public AnimalService(IAnimalRepository repository, IMapper mapper, ILogger<AnimalService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AnimalReadDto> CreateAnimalAsync(AnimalCreateDto createDto)
        {
            var animal = _mapper.Map<Animal>(createDto);
            await _repository.AddAsync(animal);
            await _repository.SaveChangesAsync();
            return _mapper.Map<AnimalReadDto>(animal);
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            var animal = await _repository.GetByIdAsync(id);
            if (animal == null)
                return false;

            await _repository.DeleteAsync(animal);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AnimalReadDto>> GetAllAnimalsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all animals from repository.");
                var animals = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<AnimalReadDto>>(animals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching animals from the repository.");
                throw;
            }
        }

        public async Task<AnimalReadDto?> GetAnimalByIdAsync(int id)
        {
            var animal = await _repository.GetByIdAsync(id);
            return animal == null ? null : _mapper.Map<AnimalReadDto>(animal);
        }

        public async Task<bool> UpdateAnimalAsync(int id, AnimalUpdateDto updateDto)
        {
            var animal = await _repository.GetByIdAsync(id);
            if (animal == null)
                return false;

            _mapper.Map(updateDto, animal);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
