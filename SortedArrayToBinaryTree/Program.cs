using System;

namespace SortedArrayToBinaryTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { -10, -3, 0, 5, 9 };

            var result = SortedArrayToBST(arr);
        }
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            var cor = nums[nums.Length / 2];

            var start = new TreeNode(cor);

            //left
            var leftIndex = nums.Length / 2 - 1;
            for (int i = leftIndex; i >= 0; i--)
            {
                var current = new TreeNode(nums[i]);
                start = current;
            }

            var a = 0;

            return null;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}