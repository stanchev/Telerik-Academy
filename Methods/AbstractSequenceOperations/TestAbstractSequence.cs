using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSequenceOperations
{
    class TestAbstractSequence
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Min of sequence [2, 3, 4, 0, 1, 2, 5] is : {0}", AbstractSequence<byte>.MinimumOfSequence(2, 3, 4, 0, 1, 2, 5));
                Console.WriteLine("Max of sequence [2, 3, 4, 0, 1] is : {0}", AbstractSequence<byte>.MaximumOfSequence(2, 3, 4, 0, 1));
                Console.WriteLine("Average of sequence [2,3,4] is : {0}", AbstractSequence<byte>.AverageOfSequence(2, 3, 4));
                Console.WriteLine("Sum of sequence [2, 3, 4, 0, 1, 2, 5] is : {0}", AbstractSequence<int>.SumOfSequence(2, 3, 4, 0, 1, 2, 5));
                Console.WriteLine("Product of sequence [2, 3, 4, 1, 1, 2, 5] is : {0}", AbstractSequence<byte>.ProductOfSequence(2, 3, 4, 1, 1, 2, 5));
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
