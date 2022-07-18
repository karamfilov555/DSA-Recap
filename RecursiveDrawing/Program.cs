using System;

namespace RecursiveDrawing
{
    internal class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            DrawTop(n);
        }

        private static void DrawTop(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));
            DrawTop(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
