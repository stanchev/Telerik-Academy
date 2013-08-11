using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ReplaceWholeWordsInFile
{
    class Program
    {
        /// <summary>
        /// Replace all word occurrences in given file by path name.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchWord"></param>
        /// <param name="replaceWord"></param>
        static void ReplaceWordOccurencesInFile(string path, string searchWord, string replaceWord)
        {
            string pattern = string.Format(@"\b{0}\b", searchWord);
            Regex regReplace = new Regex(pattern,RegexOptions.Compiled);

            using (StreamReader read = new StreamReader(path))
            {
                using (StreamWriter write = new StreamWriter("replace.txt"))
                {
                    string line;
                    while ((line = read.ReadLine()) != null)
                    {
                        string replacedLine = regReplace.Replace(line, replaceWord);
                        write.WriteLine(replacedLine);
                    }
                }
            }
            string fileName = Path.GetFileName(path);
            File.Delete(path);
            File.Move("replace.txt", fileName);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                ReplaceWordOccurencesInFile(filePath, "start", "finish");
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
