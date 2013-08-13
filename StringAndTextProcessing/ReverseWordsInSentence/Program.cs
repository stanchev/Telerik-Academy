using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsInSentence
{
    class Program
    {
        /// <summary>
        /// Reverse words in given sentence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        static string ReverseSentence(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ', ',', '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] signs = sentence.Split(words,StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            StringBuilder reverseSentence = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                reverseSentence.Append(words[i] + signs[i]);
            }

            return reverseSentence.ToString();
        }

        static void Main(string[] args)
        {
            string sentence = "C# is not C++, not PHP and not Delphi!";
            Console.WriteLine(ReverseSentence(sentence));
        }
    }
}
