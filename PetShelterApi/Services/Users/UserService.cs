using AutoMapper;
using PetShelterApi.Dtos;
using PetShelterApi.Models;
using PetShelterApi.Repositories;
using Microsoft.Extensions.Logging;
using PetShelterApi.Repositories.UserRepository;
using PetShelterApi.Dtos.userDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PetShelterApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository, IMapper mapper, ILogger<UserService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        

        public async Task<UserRegisterDto> AddUser(UserRegisterDto createDto)
        {
            var user = _mapper.Map<User>(createDto);
            await _repository.AddAsync(user);
            
            return _mapper.Map<UserRegisterDto>(user);
        }

        public async Task<UserRegisterDto?> GetUserByUserName(string username)
        {
            var user = await _repository.GetByNameAsync(username);
            return user == null ? null : _mapper.Map<UserRegisterDto>(user);
        }
    }
}
