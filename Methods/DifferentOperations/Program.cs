using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseNumber;

namespace DifferentOperations
{
    class Program
    {
        static int GetReverseNumber(int number)
        {
            int reversed = ReverseNumber.ReverseNumber.GetReversesNumber(number);
            return reversed;
        }

        static double AverageOfInteger(params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            double average = (double)sum / nums.Length;
            return average;
        }

        static double LinearEquation(double a, double b)
        {
            double x = -b / a;
            return x;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Simple program with different functions.");
                Console.WriteLine("1. Reverse Number");
                Console.WriteLine("2. Get average of sequence of integers.");
                Console.WriteLine("3. Solve a linear equation.");
                Console.WriteLine("4. Exit.");
                Console.Write("Enter your choice[1-4]: ");
                int choice = 0;
                int.TryParse(Console.ReadLine(), out choice);
                if (choice >= 1 && choice <= 4)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            int number = 0;
                            Console.WriteLine("Number must be non-negative.");
                            do
                            {
                                Console.Write("Enter integer number : ");
                                number = int.Parse(Console.ReadLine());
                            } while (number < 0);
                            Console.WriteLine(GetReverseNumber(number));
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            int count = 0;
                            Console.WriteLine("Sequence must be not empty.");
                            do
                            {
                                Console.Write("Enter count of integer : ");
                                count = int.Parse(Console.ReadLine());
                            } while (count <= 0);
                            int[] nums = new int[count];
                            for (int i = 0; i < count; i++)
                            {
                                Console.Write("Enter #{0} : ", i + 1);
                                nums[i] = int.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("Average of nums is : {0}", AverageOfInteger(nums));
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Enter 'a' and 'b'.'a' must not be a zero.");
                            int a = 0, b = 0;
                            do
                            {
                                Console.Write("Enter 'a' : ");
                                a = int.Parse(Console.ReadLine());
                            } while (a == 0);
                            Console.Write("Enter 'b' : ");
                            b = int.Parse(Console.ReadLine());
                            Console.WriteLine(LinearEquation(a, b));
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                            break;
                        case 4:
                            return;
                    }
                }
            } while (true);
        }
    }
}
