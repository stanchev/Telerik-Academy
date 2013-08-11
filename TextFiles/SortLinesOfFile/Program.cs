using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortLinesOfFile
{
    class Program
    {
        /// <summary>
        /// Read file content by given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static List<string> ReadFileContent(string path)
        {
            List<string> fileContent = new List<string>();
            using (TextReader read = new StreamReader(path))
            {
                string line = null;
                while ((line = read.ReadLine()) != null)
                {
                    fileContent.Add(line);
                }
            }
            return fileContent;
        }

        /// <summary>
        /// Sort file lines.
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        static List<string> SortFileLines(List<string> fileContent)
        {
            fileContent.Sort();
            return fileContent;
        }

        /// <summary>
        /// Write result to file.
        /// </summary>
        /// <param name="fileContent"></param>
        static void WriteResultFile(List<string> fileContent)
        {
            using (TextWriter write = new StreamWriter("result.txt"))
            {
                for (int i = 0; i < fileContent.Count; i++)
                {
                    write.WriteLine(fileContent[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                List<string> fileContent = ReadFileContent(filePath);
                fileContent = SortFileLines(fileContent);
                WriteResultFile(fileContent);
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
