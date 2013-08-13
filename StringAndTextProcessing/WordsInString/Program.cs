using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WordsInString
{
    class Program
    {
        /// <summary>
        /// Return words and count of occurrences in text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static Dictionary<string,int> GetWordsInformation(string text)
        {
            string pattern = @"\w+";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled);

            MatchCollection matches = regExpression.Matches(text);

            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                if (words.ContainsKey(match.Groups[0].Value))
                {
                    words[match.Groups[0].Value]++;
                }
                else
                {
                    words.Add(match.Groups[0].Value, 1);
                }
            }
            return words;
        }

        /// <summary>
        /// Print words information.
        /// </summary>
        /// <param name="words"></param>
        static void PrintWordsInformation(Dictionary<string,int> words)
        {
            foreach (KeyValuePair<string, int> item in words)
            {
                Console.WriteLine("Word {0} persist {1} counts.", item.Key, item.Value);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter text : ");
            string text = Console.ReadLine();
            Dictionary<string, int> words = GetWordsInformation(text);
            PrintWordsInformation(words);
        }
    }
}
