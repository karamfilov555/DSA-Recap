using System;

namespace RecursiveFactoriel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactoriel(n));
        }

        private static int GetFactoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * GetFactoriel(n - 1);
        }
    }
}
