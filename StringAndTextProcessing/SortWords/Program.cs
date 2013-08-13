using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortWords
{
    class Program
    {
        /// <summary>
        /// Read and sort words in given text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string[] SortWords(string text)
        {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            return words;
        }

        /// <summary>
        /// Print words.
        /// </summary>
        /// <param name="words"></param>
        static void PrintWords(string[] words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter words with space between them : ");
            string words = Console.ReadLine();
            PrintWords(SortWords(words));
        }
    }
}
