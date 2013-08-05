using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(Environment.TickCount);
            for (int i = 0; i < 10; i++)
            {
                int number = rand.Next(100, 201);
                Console.WriteLine("Random #{0} : {1}", i + 1, number);
            }
        }
    }
}
