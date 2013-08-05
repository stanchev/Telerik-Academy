using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastDigitAsWord
{
    class LastDigitAsWord
    {
        /// <summary>
        /// Convert last digit of integer number to English word.
        /// </summary>
        /// <param name="number">Integer number</param>
        /// <returns>English word of digit</returns>
        static string ConvertLastDigitToWord(int number)
        {
            string stringNumber = number.ToString();
            char lastDigit = stringNumber[stringNumber.Length - 1];
            string word = null;
            switch (lastDigit)
            {
                case '0': word = "zero"; break;
                case '1': word = "one"; break;
                case '2': word = "two"; break;
                case '3': word = "three"; break;
                case '4': word = "four"; break;
                case '5': word = "five"; break;
                case '6': word = "six"; break;
                case '7': word = "seven"; break;
                case '8': word = "eight"; break;
                case '9': word = "nine"; break;
            }
            return word;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertLastDigitToWord(10));
            Console.WriteLine(ConvertLastDigitToWord(234));
        }
    }
}
