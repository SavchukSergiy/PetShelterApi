using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShelterApi.Data;
using PetShelterApi.Dtos;
using PetShelterApi.Models;
using PetShelterApi.Services;

namespace PetShelterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET: api/animals
        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            return Ok(animals);
        }

        // GET: api/animals/5
        [HttpGet("{id}")]
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
