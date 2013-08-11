using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadFileAndPrintOddFiles
{
    class Program
    {
        /// <summary>
        /// Read odd lines in file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static string ReadOddLinesOfTextFile(string path)
        {
            StringBuilder oddLines = new StringBuilder();
            using (TextReader file = new  StreamReader(path))
            {
                string line = null;
                int lineCount = 0;
                while ((line = file.ReadLine()) != null)
                {
                    lineCount++;
                    if (lineCount % 2 != 0)
                    {
                        oddLines.Append(line + "\n");
                    }
                }
            }
            return oddLines.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                string oddLines = ReadOddLinesOfTextFile(filePath);
                Console.WriteLine("Odd lines of file: \n{0}", oddLines);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
