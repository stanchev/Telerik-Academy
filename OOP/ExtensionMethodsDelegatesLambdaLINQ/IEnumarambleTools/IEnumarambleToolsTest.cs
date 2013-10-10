using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumarambleTools
{
    class IEnumarambleToolsTest
    {
        static void Main(string[] args)
        {
            List<int> p = new List<int>();
            p.Add(10);
            p.Add(20);
            p.Add(-10);
            p.Add(0);
            p.Add(5);
            Console.WriteLine(p.CustomSum());
            Console.WriteLine(p.Min());
            Console.WriteLine(p.Max());
            Console.WriteLine(p.CustomProduct());
            Console.WriteLine(p.CustomAverage());
        }
    }
}