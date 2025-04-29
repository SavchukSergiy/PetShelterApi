using Microsoft.AspNetCore.Mvc;
using PetShelterApi.Models;
using PetShelterApi.Services.Auth;
using PetShelterApi.Services.Users;
using PetShelterApi.Dtos.userDto;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PetShelterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            var createdUser = await _userService.AddUser(registerDto);
            

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var user = await _userService.GetUserByUserName(loginDto.Username);

            if (user == null || user.Password != loginDto.Password)
            {
                return Unauthorized("Invalid username or password.");
            }

            var usermodel = _mapper.Map<User>(user);

            var token = _jwtTokenGenerator.GenerateToken(usermodel);

            return Ok(new { Token = token });
        }
    }
}
