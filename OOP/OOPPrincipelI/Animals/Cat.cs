﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Cat : Animal
    {
        public Cat(string name, int age, Genders sex)
            : base(name, age, sex)
        {

        }

        public override void SaySomething()
        {
            Console.WriteLine("I'm Cat, miau miau");
        }
    }
}
