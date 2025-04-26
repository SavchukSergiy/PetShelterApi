using Microsoft.AspNetCore.Mvc;
using PetShelterApi.Models;
using PetShelterApi.Services.Auth;
using PetShelterApi.Services.Users;
using PetShelterApi.Dtos.userDto;

namespace PetShelterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IUserService userService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
                Role = registerDto.Role
            };

            _userService.AddUser(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto loginDto)
        {
            var user = _userService.GetUserByUserName(loginDto.Username);

            if (user == null || user.Password != loginDto.Password)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
