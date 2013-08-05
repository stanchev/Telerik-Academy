using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSequenceOperations
{
    class AbstractSequence<T>
    {
        private static bool CheckForEmptySequence(params T[] nums)
        {
            if (nums.Length == 0)
            {
                return true;
            }
            return false;
        }

       public static T MinimumOfSequence(params T[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                dynamic min = nums[0];
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

       public static T MaximumOfSequence(params T[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                dynamic max = nums[0];
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

       public static double SumOfSequence(params T[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                dynamic sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                }
                return sum;
            }
        }

       public static double AverageOfSequence(params T[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                double sum = SumOfSequence(nums);
                double average = (double)sum / nums.Length;
                return average;
            }
        }

       public static Int64 ProductOfSequence(params T[] nums)
        {
            if (CheckForEmptySequence(nums))
            {
                throw new ApplicationException("Empty sequence not allowed");
            }
            else
            {
                dynamic product = 1;
                for (int i = 0; i < nums.Length; i++)
                {
                    product *= nums[i];
                }
                return product;
            }
        }
    }
}
