using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InsertLineNumbersInFile
{
    class Program
    {
        /// <summary>
        /// Create file with line numbers in front by given file.
        /// </summary>
        /// <param name="path"></param>
        static void CreateFileWithLineNumbers(string path)
        {
            string newFileName = Path.GetFileNameWithoutExtension(path) + "WithLines" + Path.GetExtension(path);
            using (TextWriter write = new StreamWriter(newFileName, false))
            {
                using (TextReader read = new StreamReader(path))
                {
                    string line = null;
                    int lineCount = 0;
                    while ((line = read.ReadLine()) != null)
                    {
                        lineCount++;
                        write.WriteLine(lineCount + " " + line);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                CreateFileWithLineNumbers(filePath);
                Console.WriteLine("Operation complete");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
