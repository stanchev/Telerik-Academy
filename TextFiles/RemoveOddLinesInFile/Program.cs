using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RemoveOddLinesInFile
{
    class Program
    {
        /// <summary>
        /// Remove odd lines in given file.
        /// </summary>
        /// <param name="path"></param>
        static void RemoveOddLines(string path)
        {
            using (TextWriter write = new StreamWriter("replace.txt"))
            {
                using (TextReader read = new StreamReader(path))
                {
                    string line = null;
                    int lineNumber = 0;
                    while ((line = read.ReadLine()) != null)
                    {
                        lineNumber++;
                        if ((lineNumber % 2) == 0)
                        {
                            write.WriteLine(line);
                        }
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
                RemoveOddLines(filePath);
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
