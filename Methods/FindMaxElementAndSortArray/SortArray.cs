using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxElementAndSortArray
{
    class SortArray
    {
        static int FindMaxElementInArray(int startIndex, int[] array)
        {
            int maxElement = array[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        static int[] SortArrayDescending(int[] array)
        {
            List<int> sortArray = new List<int>(array);
            for (int i = 0; i < sortArray.Count; i++)
            {
                int maxElement = FindMaxElementInArray(i, sortArray.ToArray());
                int index = sortArray.IndexOf(maxElement);
                int temp = sortArray[i];
                sortArray[i] = maxElement;
                sortArray[index] = temp;
            }
            return sortArray.ToArray();
        }

        static int[] SortArrayAscending(int[] array)
        {
            int[] sortArray = SortArrayDescending(array);
            Array.Reverse(sortArray);
            return sortArray;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] array = { 0, 18, 7, 3, 5, 9, 10 };
            Console.WriteLine("Max element in array is : {0}", FindMaxElementInArray(0, array));
            int[] sortArrayDescending = SortArrayDescending(array);
            int[] sortArrayAscending = SortArrayAscending(array);

            Console.Write("Sorted descending : ");
            PrintArray(sortArrayDescending);
            Console.Write("Sorted ascending : ");
            PrintArray(sortArrayAscending);

        }
    }
}
