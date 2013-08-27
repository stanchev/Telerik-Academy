using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tomcat : Cat
    {
        public new Genders Sex { get; private set; }

        public Tomcat(string name, int age)
            : base(name, age, Genders.Male)
        {

        }
    }
}
