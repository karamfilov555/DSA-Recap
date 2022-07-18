using System;
using System.Linq;

namespace ReverseRecursive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();

            ReverseRecursive(nums, nums.Length - 1);
        }

        private static void ReverseRecursive(int[] nums, int index)
        {
            if (index == 0)
            {
                Console.Write(nums[0]);
                return;
            }

            Console.Write($"{nums[index]} ");
            ReverseRecursive(nums, index - 1);
        }
    }
}
