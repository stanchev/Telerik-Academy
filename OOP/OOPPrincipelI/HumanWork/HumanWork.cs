/*Define abstract class Human with first name and last name. Define new class Student which is derived from Human and
 * has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and
 * method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties
 * for this hierarchy. Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy()
 * extension method). Initialize a list of 10 workers and sort them by money per hour in descending order. Merge the
 * lists and sort them by first name and last name.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanWork
{
    class HumanWork
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(Environment.TickCount);

            List<Student> students = new List<Student>(10);
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("Ivan" + i, "Ivanov" + i, rnd.Next(1, 7)));
            }

            students = students.OrderBy(m => m.Grade).ToList();

            List<Worker> workers = new List<Worker>(10);
            for (int i = 10; i < 20; i++)
            {
                workers.Add(new Worker("Ivan" + i, "Ivanov" + i, rnd.Next(200, 601), rnd.Next(4, 9)));
            }

            workers = workers.OrderByDescending(m => m.MoneyPerHour()).ToList();

            List<Human> h = new List<Human>();
            h.AddRange(students);
            h.AddRange(workers);
            //use sort with LINQ
            h.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToList().ForEach(m =>
            {
                Console.WriteLine(m);
            }
            );
            // use sort with implemented IComparable
            h.Sort();
            Console.WriteLine("------------------------------");
            foreach (Human item in h)
            {
                Console.WriteLine(item);
            }
        }
    }
}
