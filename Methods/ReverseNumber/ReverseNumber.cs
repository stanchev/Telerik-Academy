using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
   public class ReverseNumber
    {
        public static int GetReversesNumber(int number)
        {
            string num = number.ToString();
            StringBuilder reversesNumber = new StringBuilder(num.Length);
            for (int i = num.Length - 1; i >= 0; i--)
            {
                reversesNumber.Append(num[i]);
            }
            return int.Parse(reversesNumber.ToString());
        }

        static void Main(string[] args)
        {
            int number = 256;
            Console.WriteLine("Reversed number of {0} is {1}",number,GetReversesNumber(number));
        }
    }
}
