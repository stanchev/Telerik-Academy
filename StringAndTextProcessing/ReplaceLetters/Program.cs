using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReplaceLetters
{
    class Program
    {
        /// <summary>
        /// Replace consecutive letters in string using Regular expression.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string ReplaceSameLettersRegular(string text)
        {
            string pattern = @"(\w)\1+";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled);

            return regExpression.Replace(text, "$1");
        }

        /// <summary>
        /// Replace consecutive letters in string iterative.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string ReplaceSameLetters(string text)
        {
            StringBuilder replacedText = new StringBuilder();
            for (int i = 0; i < text.Length - 1; i++)
            {
                int count = 0;
                for (int j = i + 1; j < text.Length; j++)
                {
                    if (text[i] == text[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                replacedText.Append(text[i]);
                i += count;
            }
            return replacedText.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter text : ");
            string text = Console.ReadLine();
            Console.WriteLine("Iterative: {0}", ReplaceSameLetters(text));
            Console.WriteLine("Regular expression: {0}", ReplaceSameLettersRegular(text));
        }
    }
}
