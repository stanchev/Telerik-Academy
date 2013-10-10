using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStudent
{
    class GetStudentTest
    {
        public static IEnumerable<Student> FindStudentsByName(Student[] students)
        {
            var result = from student in students
                         where student.FirstName.CompareTo(student.LastName) < 0
                         select student;

            return result;   //students.Where(m => m.FirstName.CompareTo(m.LastName) < 0 );
        }

        public static IEnumerable<Student> FindStudentsByAge(Student[] students)
        {
            var result = from student in students
                         where student.Age >= 18 && student.Age <= 24
                         select student;

            return result;
        }

        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine("{0}  {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine(new string('-',30));
        }
        static void Main(string[] args)
        {
            Student[] students = new Student[6];

            students[0] = new Student("Ivan", "Ivanov", 18);
            students[1] = new Student("Anton", "Antonov", 20);
            students[2] = new Student("Stamat", "Angelov", 23);
            students[3] = new Student("Pe6o", "Petrov", 9);
            students[4] = new Student("Mariika", "Angelova", 24);
            students[5] = new Student("Mariika", "Petrova", 25);

            IEnumerable<Student> searchedStudents = FindStudentsByName(students);
            PrintStudents(searchedStudents);
            searchedStudents = FindStudentsByAge(students);
            PrintStudents(searchedStudents);

            var sortedStudents = 
                students.OrderByDescending(m => m.FirstName).ThenByDescending(m => m.LastName);
            PrintStudents(sortedStudents);

            sortedStudents = from student in students
                             orderby student.FirstName descending,student.LastName descending
                             select student;
            PrintStudents(sortedStudents);
        }
    }
}
