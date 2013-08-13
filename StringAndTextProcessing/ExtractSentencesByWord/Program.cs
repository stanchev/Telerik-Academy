using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractSentencesByWord
{
    class Program
    {
        /// <summary>
        /// Return sentences which contain given word.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        static List<string> ExtractSenteces(string text, string word)
        {
            string pattern = string.Format(@"[^\.]*\b{0}\b[^\.]*\.", word);
            Regex regExpression = new Regex(pattern);
            List<string> sentences = new List<string>();

            MatchCollection matches = regExpression.Matches(text);
            foreach (Match item in matches)
            {
                sentences.Add(item.Value.Trim(' '));   
            }
            return sentences;
        }

        /// <summary>
        /// Print list of sentences.
        /// </summary>
        /// <param name="sentences"></param>
        static void PrintSentences(List<string> sentences)
        {
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }

        static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            List<string> sentences = ExtractSenteces(text, "in");
            PrintSentences(sentences);
        }
    }
}
