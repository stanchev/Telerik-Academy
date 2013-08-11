using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReplaceSubstringInFile
{
    class Program
    {
        /// <summary>
        /// Replace all substring occurrences in given file by path name.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchSubstring"></param>
        /// <param name="replaceSubstring"></param>
        static void ReplaceSubstringOccurencesInFile(string path, string searchSubstring, string replaceSubstring)
        {
            using (StreamReader read = new StreamReader(path))
            {
                using (StreamWriter write = new StreamWriter("replace.txt"))
                {
                    string line;
                    while ((line = read.ReadLine()) != null)
                    {
                        string newLine = line.Replace(searchSubstring, replaceSubstring);
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
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                ReplaceSubstringOccurencesInFile(filePath, "start", "finish");
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
