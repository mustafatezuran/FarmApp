using FarmApp.Domain.Models;
using FarmApp.Infrastructure.Data;

namespace FarmApp.Application.Services
{
    public class AnimalService
    {
        private readonly AnimalRepository _animalRepository;

        public AnimalService(AnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public List<Animal> GetAllAnimals()
        {
            return _animalRepository.GetAll();
        }

        public bool AddAnimal(Animal animal)
        {
            if (_animalRepository.Exists(animal.Name))
            {
                return false;
            }

            _animalRepository.Add(animal);
            return true;
        }

        public void RemoveAnimal(Animal animal)
        {
            _animalRepository.Remove(animal);
        }
    }
}

