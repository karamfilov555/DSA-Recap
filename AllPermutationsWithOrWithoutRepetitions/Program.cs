using System;

namespace EightQueensPuzzle
{
    internal class Program
    {
        private static char[] elements;

        static void Main()
        {
            elements = new char[] { 'A', 'B', 'C', 'D' };

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            var used = new HashSet<char> { elements[index] }; //If you want all Permutations with repetitions comment this line 

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i])) // and this one
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                    used.Add(elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {

            (elements[first], elements[second]) = (elements[second], elements[first]);
        }
    }
}
