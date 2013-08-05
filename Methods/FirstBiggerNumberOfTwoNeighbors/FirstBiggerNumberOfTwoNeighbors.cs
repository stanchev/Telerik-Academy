using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighborsInArray;

namespace FirstBiggerNumberOfTwoNeighbors
{
    class FirstBiggerNumberOfTwoNeighbors
    {
        /// <summary>
        /// Get index of the first element in array that is bigger than its neighbors, or -1, if there's no such element
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Index of element or -1.</returns>
        static int GetIndexOfBiggerElement(int[] array)
        {
            for (int i = 1; i < array.Length - 2; i++)
            {
                if (NeighborsInGivenArray.CheckElementAtIndex(i,array))
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] array = { 0, 0, 0, 0, 0, 0, 0, 0 };

            Console.WriteLine("Index of first bigger element than its neighbors is : {0}",
                GetIndexOfBiggerElement(array));
        }
    }
}
