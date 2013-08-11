using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace DeleteWordsStartWithPrefix
{
    class Program
    {
        /// <summary>
        /// Remove words start with given prefix in given file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="prefix"></param>
        static void RemoveWordsStartWithPrefixInFile(string path, string prefix)
        {
            string pattern = string.Format(@"\b{0}\w*\b", prefix);
            Regex regReplace = new Regex(pattern,RegexOptions.Compiled);

            using (StreamReader read = new StreamReader(path))
            {
                using (StreamWriter write = new StreamWriter("replace.txt"))
                {
                    string line = null;
                    while ((line = read.ReadLine()) != null)
                    {
                        string replacedLine = regReplace.Replace(line, string.Empty);
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
                RemoveWordsStartWithPrefixInFile(filePath, "test");
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
