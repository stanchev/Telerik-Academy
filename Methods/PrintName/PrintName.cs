using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintName
{
    class PrintName
    {
        static string GetAndPrintName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            return String.Format("Hello, {0}", name);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetAndPrintName());
        }
    }
}
