using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborsInArray
{
    public class NeighborsInGivenArray
    {
        /// <summary>
        /// Check element at given index is bigger than its two neighbors.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool CheckElementAtIndex(int index, int[] array)
        {
            if ((index - 1 < 0) || (index + 1 >= array.Length))
            {
                throw new IndexOutOfRangeException();
            }
            if ((array[index] > array[index + 1]) && (array[index] > array[index - 1]))
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int[] array = { 0, 2, 3, 4, 3, 5, 2, 1 };
            int index = 3;
            try
            {
                Console.WriteLine("Element {0} at index {1} is bigger : {2}",
                    array[index], index, CheckElementAtIndex(index, array));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Neighbors not exist or index out of range");
            }
        }
    }
}
