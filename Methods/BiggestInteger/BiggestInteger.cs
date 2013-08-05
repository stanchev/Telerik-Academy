using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestInteger
{
    class BiggestInteger
    {
        /// <summary>
        /// Returns biggest integer.
        /// </summary>
        /// <param name="first">First integer</param>
        /// <param name="second">Second integer</param>
        /// <returns>Biggest integer.</returns>
        static int GetMax(int first, int second)
        {
            if (first >= second)
            {
                return first;
            }

            return second;
        }

        /// <summary>
        /// Read integer from console.
        /// </summary>
        /// <returns>Readed integer</returns>
        static int ReadInteger()
        {
            Console.Write("Enter integer : ");
            int result = int.Parse(Console.ReadLine());
            return result;
        }

        static void Main(string[] args)
        {
            int firstInt = ReadInteger();
            int secondInt = ReadInteger();
            int thirdInt = ReadInteger();
            int maxInt = GetMax(GetMax(firstInt,secondInt),thirdInt);
            Console.WriteLine("The biggest integer of is {0}",maxInt);
        }
    }
}
