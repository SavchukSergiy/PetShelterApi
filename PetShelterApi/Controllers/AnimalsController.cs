using Microsoft.AspNetCore.Mvc;
using PetShelterApi.Dtos;
using PetShelterApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace PetShelterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly ILogger<AnimalsController> _logger;

        public AnimalsController(IAnimalService animalService, ILogger<AnimalsController> logger)
        {
            _animalService = animalService;
            _logger = logger;
        }

        // GET: api/animals
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnimals()
        {
            try
            {
                _logger.LogInformation("Fetching all animals from the database.");
                var animals = await _animalService.GetAllAnimalsAsync();
                return Ok(animals);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while fetching animals.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/animals/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAnimal(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        // POST: api/animals
        [HttpPost]
        public async Task<IActionResult> PostAnimal([FromBody] AnimalCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAnimal = await _animalService.CreateAnimalAsync(createDto);
            return CreatedAtAction(nameof(PostAnimal), new { id = createdAnimal.Id }, createdAnimal);
        }


        // PUT: api/animals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, [FromBody] AnimalUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _animalService.UpdateAnimalAsync(id, updateDto);
            if (!success)
                return NotFound();

            return NoContent();
        }


        // DELETE: api/animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var success = await _animalService.DeleteAnimalAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
