using FarmApp.Domain.Models;

namespace FarmApp.Infrastructure.Data
{
    public class AnimalRepository
    {
        private List<Animal> _animals = new List<Animal>();

        public void Add(Animal animal)
        {
            _animals.Add(animal);
        }

        public bool Exists(string name)
        {
            return _animals.Any(p => p.Name.ToUpper() == name.ToUpper());
        }

        public List<Animal> GetAll()
        {
            return _animals;
        }

        public void Remove(Animal animal)
        {
            _animals.Remove(animal);
        }
    }
}
