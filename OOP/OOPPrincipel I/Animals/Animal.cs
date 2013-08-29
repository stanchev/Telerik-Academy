using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Genders Sex { get; set; }

        public Animal(string name, int age, Genders sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        abstract public void SaySomething();

        public static Dictionary<string, double> GetAverageAge(IEnumerable<Animal> animals)
        {
            var animalGroups =
                from animal in animals
                group animal by animal.GetType().Name into Groups
                let name = Groups.Key
                let average = Groups.Average(a => a.Age)
                select new { name, average };

            Dictionary<string, double> averageAgeOfAnimals = animalGroups.ToDictionary(k => k.name,v => v.average);

            return averageAgeOfAnimals;
        }
    }
}
