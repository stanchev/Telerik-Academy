using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace RepeatedWords
{
    class Program
    {
        /// <summary>
        /// Read words from file by given file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static Dictionary<string, int> ReadWords(string path)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (TextReader read = new StreamReader(path))
            {
                string word = null;
                while ((word = read.ReadLine()) != null)
                {
                    if (!words.ContainsKey(word))
                    {
                        words.Add(word, 0);
                    }
                }
            }
            return words;
        }

        /// <summary>
        /// Return count of words contained in given text file.
        /// </summary>
        /// <param name="wordFilePath">Path to file contained words.</param>
        /// <param name="filePath">Path to file in which we searching words.</param>
        /// <returns></returns>
        static Dictionary<string,int> GetCountOfWords(string wordFilePath,string filePath)
        {
            string pattern = @"\b\w+\b";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled);
            Dictionary<string, int> words = ReadWords(wordFilePath);
            using (TextReader read = new StreamReader(filePath))
            {
                string line = null;
                while ((line = read.ReadLine()) != null)
                {
                    MatchCollection matches = regExpression.Matches(line);
                    foreach (Match match in matches)
                    {
                        if (words.ContainsKey(match.Value))
                        {
                            words[match.Value]++;
                        }
                    }
                }
            }
            var sortedWords = words.OrderByDescending(m => m.Value);
            words = sortedWords.ToDictionary(m => m.Key, k => k.Value);
            return words;
        }

        /// <summary>
        /// Write result to file.
        /// </summary>
        /// <param name="words"></param>
        static void WriteResult(Dictionary<string, int> words)
        {
            using (TextWriter write = new StreamWriter("result.txt"))
            {
                foreach (KeyValuePair<string,int> item in words)
                {
                    write.WriteLine("Word {0} repeated {1} count",item.Key,item.Value);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, int> words = GetCountOfWords("words.txt", "test.txt");
                WriteResult(words);
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
