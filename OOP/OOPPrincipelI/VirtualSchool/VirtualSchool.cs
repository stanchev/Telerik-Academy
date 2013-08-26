/*We are given a school. In the school there are classes of students. Each class has a set of teachers. 
 * Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text 
 * identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers 
 * and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
 * Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields,
 * define the class hierarchy and create a class diagram with Visual Studio.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class VirtualSchool
    {
        static void Main(string[] args)
        {
            School ivanVazov = new School("Ivan Vazov");
            SchoolClass A1 = new SchoolClass("A1");
            A1.AddStudent("Ivan");
            A1.AddStudent("Mariika","mimeto");
            A1.AddTeacher(new Teacher("Pe6o"));
            ivanVazov.AddClass(A1);
            
            SchoolClass A2 = new SchoolClass("A2");
            A2.AddStudent("Ivan");
            A2.AddStudent("Pe6o");
            A2.AddTeacher(new Teacher("Stamat",null,new Discipline("Matematika",10,10,"slojna e")));
            A2.AddTeacher(new Teacher("Grudi", null, new Discipline("Himiq", 10, 5), new Discipline("Fizika", 8, 3)));
            ivanVazov.AddClass(A2);

            Console.WriteLine(ivanVazov.GetAllClasses());

            Console.WriteLine(ivanVazov.PrintDetailSchoolInformation());
        }
    }
}
