using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class Student : People
    {
        private int studentNumber;

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }
        }

        public Student(string name, int studentNumber, string comment = null)
            : base(name, comment)
        {
            this.studentNumber = studentNumber;
        }

        public override string ToString()
        {
            string studentInformation = "Name: " + base.Name + " Number: " + this.studentNumber;
            return studentInformation;
        }
    }
}
