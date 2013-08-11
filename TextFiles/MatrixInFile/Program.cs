using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MatrixInFile
{
    class Program
    {
        /// <summary>
        /// Read input file and fill matrix.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static int[,] ReadInputFile(string path)
        {
            int[,] matrix;

            using (StreamReader read = new StreamReader(path)) //matrix.txt
            {
                int matrixSize = int.Parse(read.ReadLine());
                matrix = new int[matrixSize, matrixSize];
                string line;
                string[] matrixRow = new string[matrixSize];
                int rowNumber = 0;
                while ((line = read.ReadLine()) != null)
                {
                    matrixRow = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < matrixSize; i++)
                    {
                        matrix[rowNumber, i] = int.Parse(matrixRow[i]);
                    }
                    rowNumber++;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Find area with maximal sum in matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static int FindAreaWithMaxSum(int[,] matrix)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }

        /// <summary>
        /// Write result to file.
        /// </summary>
        /// <param name="maxSum"></param>
        static void WriteOutputFile(int maxSum)
        {
            using (StreamWriter write = new StreamWriter("result.txt"))
            {
                write.WriteLine(maxSum);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                int[,] matrix = ReadInputFile(filePath);
                int maxSum = FindAreaWithMaxSum(matrix);
                WriteOutputFile(maxSum);
                Console.WriteLine("Operation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
