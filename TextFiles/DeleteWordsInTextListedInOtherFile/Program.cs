using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace DeleteWordsInTextListedInOtherFile
{
    class Program
    {
        /// <summary>
        /// Read words in given file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static List<string> ReadWords(string path)
        {
            List<string> words = new List<string>();
            using (TextReader read = new StreamReader(path))
            {
                string word = null;
                while ((word = read.ReadLine()) != null)
                {
                    words.Add(word);
                }
            }
            return words;
        }

        /// <summary>
        /// Delete all given words in given file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="words"></param>
        static void DeleteAllGivenWordsInFile(string path, List<string> words)
        {
            string wordPattern = null;
            for (int i = 0; i < words.Count; i++)
			{
                wordPattern += words[i] + "|";
			}
            wordPattern = wordPattern.Remove(wordPattern.Length - 1,1);
            string pattern = string.Format(@"\b({0})\b", wordPattern);
            Regex regRemove = new Regex(pattern, RegexOptions.Compiled);

            using (TextWriter write = new StreamWriter("replace.txt"))
            {
                using (TextReader read = new StreamReader(path))
                {
                    string line = null;
                    while ((line = read.ReadLine()) != null)
                    {
                        string newLine = regRemove.Replace(line, string.Empty);
                        write.WriteLine(newLine);
                    }
                }
            }
            string fileName = Path.GetFileName(path);
            File.Delete(path);
            File.Move("replace.txt", fileName);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to words file : ");
            string wordsFilePath = Console.ReadLine();
            Console.Write("Enter path to file : ");
            string filePath = Console.ReadLine();
            try
            {
                DeleteAllGivenWordsInFile(filePath, ReadWords(wordsFilePath));
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
