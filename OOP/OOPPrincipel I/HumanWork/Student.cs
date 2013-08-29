using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanWork
{
    class Student : Human
    {
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public Student(string firstName, string lastName)
            : this(firstName, lastName, 0)
        {

        }

        public override string ToString()
        {
            return base.ToString() + " Grade: " + this.Grade;
        }
    }
}
