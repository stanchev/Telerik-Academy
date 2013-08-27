/*Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are
 * Animals. All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals
 * are described by age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a
 * specific sound. Create arrays of different kinds of animals and calculate the average age of each kind of animal using
 * a static method (you may use LINQ).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class AnimalsTest
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>(10);

            animals.Add(new Tomcat("Ivan", 5));
            animals.Add(new Tomcat("Go6o", 7));
            animals.Add(new Kitten("Ivanka", 10));
            animals.Add(new Kitten("Gerganka", 10));
            animals.Add(new Cat("Mimi", 20, Genders.Female));
            animals.Add(new Cat("Stamat", 10, Genders.Male));
            animals.Add(new Frog("Jab", 1, Genders.Male));
            animals.Add(new Frog("Kvachka", 3, Genders.Female));
            animals.Add(new Dog("Stamat", 11, Genders.Male));
            animals.Add(new Dog("Grudi", 15, Genders.Male));

            Animal[] an = new Animal[3];
            an[0] = new Tomcat("Iovcho", 10);
            an[1] = new Kitten("Pepi", 5);
            an[2] = new Kitten("Lili", 7);

            foreach (KeyValuePair<string,double> item in Animal.AverageAge(animals))
            {
                Console.WriteLine("Animal kind: " + item.Key + "  Average age of animal kind: " + item.Value);
            }
            Console.WriteLine();
        }
    }
}
