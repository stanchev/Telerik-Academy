using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanWork
{
    abstract class Human : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public int CompareTo(object obj)
        {
            Human other = (Human)obj;

            if (this.FirstName.CompareTo(other.FirstName) == 0)
            {
                if (this.LastName.CompareTo(other.LastName) == 0)
                {
                    return 0;
                }
                else if (this.LastName.CompareTo(other.LastName) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (this.FirstName.CompareTo(other.FirstName) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
