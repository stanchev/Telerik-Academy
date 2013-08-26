using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadNumbers
{
    class Program
    {
        /// <summary>
        /// Read integer number in given range [start-end].
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        static int ReadNumber(int start, int end)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return number;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Invalid number", e);
            }
        }

        static void Main(string[] args)
        {
            int lowRange = 1, highRange = 100;
            int count = 10;
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                try
                {
                    Console.Write("Enter #{0} number in range[{1}-{2}] : ", i + 1, lowRange, highRange);
                    lowRange = numbers[i] = ReadNumber(lowRange, 100);
                    
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number");
                    i--;
                }
            }

        }
    }
}
