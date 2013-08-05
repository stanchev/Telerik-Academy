using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinary
{
   public class DecimalToBinary
    {
        /// <summary>
        /// Convert decimal number to binary.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertDecimalToBinary(int number)
        {
            StringBuilder binaryNumber = new StringBuilder();
            int mask = 1;
            for (int i = 0; i <= 31; i++)
            {
                binaryNumber.Insert(0, (number & mask));
                number = number >> 1;
            }
            return binaryNumber.ToString().TrimStart('0');
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertDecimalToBinary(-30));
        }
    }
}
