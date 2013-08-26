using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class SchoolClass : Comment
    {
        private int studentNumber = 1;
        private string className;
        private List<Teacher> teachers;
        private List<Student> students;

        public string Name
        {
            get
            {
                return this.className;
            }
        }

        public SchoolClass(string className,string comment = null)
        {
            this.className = className;
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();
            this.AddComment(comment);
        }

        public void AddStudent(string name, string comment = null)
        {
            this.students.Add(new Student(name, studentNumber, comment));
            this.studentNumber++;
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public string GetStudentsInformation()
        {
            StringBuilder students = new StringBuilder();
            foreach (Student item in this.students)
            {
                students.AppendLine(item.ToString());
            }
            return students.ToString().Trim();
        }

        public string GetTeachersInformation()
        {
            StringBuilder teachers = new StringBuilder();
            foreach (Teacher item in this.teachers)
            {
                teachers.AppendLine(item.ToString());
            }
            return teachers.ToString().Trim();
        }
    }
}
