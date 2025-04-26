using AutoMapper;
using PetShelterApi.Models;
using PetShelterApi.Dtos;

namespace PetShelterApi.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile() 
        {
            CreateMap<Animal, AnimalReadDto>();
            CreateMap<AnimalCreateDto, Animal>();
            CreateMap<AnimalUpdateDto, Animal>();
            CreateMap<Animal, AnimalUpdateDto>();
        }
    }
}
