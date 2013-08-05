using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceOperations
{
    class Sequence
    {
        static bool CheckForEmptySequence(params int[] nums)
        {
            if (nums.Length == 0)
            {
                return true;
            }
            return false;
        }

        static int MinimumOfSequence(params int[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                int min = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    if (min > nums[i])
                    {
                        min = nums[i];
                    }
                }
                return min;
            }
        }

        static int MaximumOfSequence(params int[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                int max = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    if (max < nums[i])
                    {
                        max = nums[i];
                    }
                }
                return max;
            }
        }

        static int SumOfSequence(params int[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                int sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                }
                return sum;
            }
        }

        static double AverageOfSequence(params int[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                int sum = SumOfSequence(nums);
                double average = (double)sum / nums.Length;
                return average;
            }
        }

        static Int64 ProductOfSequence(params int[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                Int64 product = 1;
                for (int i = 0; i < nums.Length; i++)
                {
                    product *= nums[i];
                }
                return product;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Min of sequence [2,3,4,0,-1,2,-5] is : {0}", MinimumOfSequence(2, 3, 4, 0, -1, 2, -5));
                Console.WriteLine("Max of sequence [2,3,4,0,-1] is : {0}", MaximumOfSequence(2, 3, 4, 0, -1));
                Console.WriteLine("Average of sequence [2,3,4] is : {0}", AverageOfSequence(2, 3, 4));
                Console.WriteLine("Sum of sequence [2,3,4,0,-1,2,-5] is : {0}", SumOfSequence(2, 3, 4, 0, -1, 2, -5));
                Console.WriteLine("Product of sequence [2,3,4,1,-1,2,-5] is : {0}", ProductOfSequence(2, 3, 4, 1, -1, 2, -5));
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
