using FarmApp.Application.Services;
using FarmApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var animals = _animalService.GetAllAnimals();
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            if (animal == null)
            {
                return BadRequest("Animal data is missing");
            }

            if (_animalService.AddAnimal(animal))
            {
                return CreatedAtAction(nameof(Get), animal);
            }
            else
            {
                return Conflict("Animal with the same name already exists");
            }
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var animal = _animalService.GetAllAnimals().Find(p => p.Name == name);
            if (animal == null)
            {
                return NotFound();
            }

            _animalService.RemoveAnimal(animal);
            return NoContent();
        }
    }
}
