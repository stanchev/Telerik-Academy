using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfGivenNumberInArray
{
    class CountOfGivenNumberInArray
    {
        /// <summary>
        /// Returns how many times given number appears in given array.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="array"></param>
        /// <returns>Repeated counts.</returns>
        static int GetCountsOfNumber(int number,int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            int[] array = { 0, 2, 3, 0, 9, 8, 0, 3, 4, 4, 4 };
            int number = 3;
            Console.WriteLine("Digit {0} exist in array {1} times", number, GetCountsOfNumber(number, array));
        }
    }
}
