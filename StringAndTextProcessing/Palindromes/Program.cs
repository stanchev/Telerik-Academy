using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Palindromes
{
    class Program
    {
        /// <summary>
        /// Return all palindroms in given text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static List<string> GetAllPalindromes(string text)
        {
            string pattern = @"[\w]{2,}";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled);
            List<string> palindromes = new List<string>();

            MatchCollection matches = regExpression.Matches(text);
            foreach (Match match in matches)
            {
                string palindrom = match.Groups[0].Value;
                bool isPalindrom = true;
                for (int i = 0; i < palindrom.Length / 2; i++)
                {
                    if (palindrom[i] != palindrom[palindrom.Length - 1 - i])
                    {
                        isPalindrom = false;
                        break;
                    }
                }
                if (isPalindrom)
                {
                    palindromes.Add(match.Groups[0].Value);
                }
            }
            return palindromes;
        }

        /// <summary>
        /// Print list of palindroms.
        /// </summary>
        /// <param name="palindromes"></param>
        static void PrinPalindromes(List<string> palindromes)
        {
            foreach (string palindrom in palindromes)
            {
                Console.WriteLine(palindrom);
            }
        }

        static void Main(string[] args)
        {
            string text = "abba baab kurtiitruk nqmanqma, jki dobreerbod";
            PrinPalindromes(GetAllPalindromes(text));
        }
    }
}
