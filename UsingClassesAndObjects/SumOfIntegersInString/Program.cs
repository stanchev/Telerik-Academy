using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfIntegersInString
{
    class Program
    {
        /// <summary>
        /// Return sums of integers of given strings.String format ("10 20 30 1 2").
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static int GetSumOfIntegers(string nums)
        {
            string[] numbers = nums.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += int.Parse(numbers[i]);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Sum of ints (43 68 9 23 318) is : {0}", GetSumOfIntegers("43 68 9 23 318"));
        }
    }
}
