using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dictionary
{
    class Program
    {
        static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        /// <summary>
        /// Create dictionary of words by given text.
        /// </summary>
        /// <param name="text"></param>
        static void FillDictionary(string text)
        {
            string pattern = @"^([^-]+)-([^-]+)$";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Multiline);

            MatchCollection matches = regExpression.Matches(text);
            foreach (Match match in matches)
            {
                dictionary.Add(match.Groups[1].Value.Trim().ToLower(), match.Groups[2].Value.Trim());
            }
        }

        static void Main(string[] args)
        {
            string text = ".NET - platform for applications from Microsoft\nCLR - managed execution environment for .NET\nnamespace - hierarchical organization of classes";

            FillDictionary(text);
            Console.WriteLine("Enter word to explain or \"exit!!!\" to exit.");
            do
            {
                Console.Write("Enter word : ");
                string input = Console.ReadLine();
                if (dictionary.ContainsKey(input))
                {
                    Console.WriteLine("Explain : {0}", dictionary[input]);
                }
                else if (input == "exit!!!")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Explain : Not have information for this word.");
                }
            } while (true);
        }
    }
}
