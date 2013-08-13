using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForbiddenWords
{
    class Program
    {
        /// <summary>
        /// Convert word to representation of asterisks.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        static string ConvertToStar(string word)
        {
            StringBuilder star = new StringBuilder(word.Length);
            for (int i = 0; i < star.Capacity; i++)
            {
                star.Append('*');
            }
            return star.ToString();
        }

        /// <summary>
        /// Return string with replaced forbidden words.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        static string ReplaceForbiddenWords(string text, string words)
        {
            string[] notAllowedWords = words.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);
            StringBuilder replacedText = new StringBuilder(text);
            for (int i = 0; i < notAllowedWords.Length; i++)
            {
                replacedText.Replace(notAllowedWords[i], ConvertToStar(notAllowedWords[i]));
            }
            return replacedText.ToString();
        }

        static void Main(string[] args)
        {

            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string notAllowedStringWords = "PHP,CLR,Microsoft";
            Console.WriteLine(ReplaceForbiddenWords(text, notAllowedStringWords));
        }
    }
}
