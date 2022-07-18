using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    internal class Program
    {
        private static int sum = 0;
        private static int counter = 0;
        static void Main()
        {
            var nums = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();

            Console.WriteLine(SumArray(nums));
        }

        private static int SumArray(List<int> nums)
        {
            if (nums.Count == counter)
            {
                return sum;
            }
         
            sum += nums[counter];
            counter++;
            return SumArray(nums);
        }
    }
}
