using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConcatenateTwoFiles
{
    class Program
    {
        /// <summary>
        /// Concatenate two text files.
        /// </summary>
        /// <param name="firstFilePath"></param>
        /// <param name="secondFilePath"></param>
        static void ConcatenateTextFiles(string firstFilePath, string secondFilePath)
        {
            string firstFileName = Path.GetFileNameWithoutExtension(firstFilePath);
            string secondFileName = Path.GetFileName(secondFilePath);
            using (TextWriter newFile = new StreamWriter(firstFileName + "+" + secondFileName, false))
            {
                using (TextReader firstFile = new StreamReader(firstFilePath))
                {
                    string firstFileContent = firstFile.ReadToEnd();
                    newFile.Write(firstFileContent);
                    using (TextReader secondFile = new StreamReader(secondFilePath))
                    {
                        string secondFileContent = secondFile.ReadToEnd();
                        newFile.Write(secondFileContent);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to first text file : ");
            string firstFilePath = Console.ReadLine();
            Console.Write("Enter path to second text file : ");
            string secondFilePath = Console.ReadLine();
            try
            {
                ConcatenateTextFiles(firstFilePath, secondFilePath);
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
