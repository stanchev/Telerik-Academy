using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRepresentation
{
    class Program
    {
        /// <summary>
        /// Print representation of number as :decimal number, hexadecimal number, percentage and in scientific notation. 
        /// </summary>
        /// <param name="number"></param>
        static void PrintNumberRepresentation(int number)
        {
            Console.WriteLine("Decimal : {0,15:d}",number);
            Console.WriteLine("Hexadecimal : {0,15:X4}", number);
            Console.WriteLine("Percent : {0,15:p}", number);
            Console.WriteLine("Scientific : {0,15:e}", number);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number : ");
            int number = int.Parse(Console.ReadLine());
            PrintNumberRepresentation(number);
        }
    }
}
