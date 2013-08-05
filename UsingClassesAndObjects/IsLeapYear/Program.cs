using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsLeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter year [xxxx] : ");
            int year = int.Parse(Console.ReadLine());
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("Year {0} is leap.", year);
            }
            else
            {
                Console.WriteLine("Year {0} is not leap.", year);
            }
        }
    }
}
