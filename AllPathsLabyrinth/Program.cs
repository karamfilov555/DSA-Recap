using System;
using System.Collections.Generic;
using System.Linq;

namespace AllPathsLabyrinth
{
    internal class Program
    {
        private static List<string> AllPaths = new List<string>();
        
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());                                   //Input:                //Output:
                                                                                        //3                     //RRDD
            var lab = new char[rows, cols];                                             //3                     //DDRR
                                                                                        //---
            for (int i = 0; i < rows; i++)                                              //-*-
            {                                                                           //--e
                var inputRow = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    lab[i, j] = inputRow[j];
                }
            }
            var directions = new List<string>();

            var counter = 0;


            MoveInLabyrinth(0, 0, lab, directions, string.Empty, ref counter) ;

            Console.WriteLine(string.Join(Environment.NewLine, AllPaths.OrderBy(x => x.Length))); //Comment if you don't want to display shortest first.
            Console.WriteLine(AllPaths.Count);
            Console.WriteLine(counter);
        }

        private static void MoveInLabyrinth(int row, int col, char[,] lab, List<string> directions, string direction, ref int counter)
        {
            counter++;
            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1)) // Outside of the matrix.
            {
                return;
            }

            if (lab[row, col] == '*' || lab[row, col] == 'v') // Cell is wall or visited.
            {
                return;
            }

            directions.Add(direction); // Make the step

            if (lab[row, col] == 'e') // This is the exit!
            {
                //Console.WriteLine(string.Join(string.Empty, directions));
                AllPaths.Add(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            MoveInLabyrinth(row - 1, col, lab, directions, "U", ref counter); //MOVE UP
            MoveInLabyrinth(row + 1, col, lab, directions, "D",ref counter); //MOVE DOWN
            MoveInLabyrinth(row, col - 1, lab, directions, "L", ref counter); //MOVE Left
            MoveInLabyrinth(row, col + 1, lab, directions, "R", ref counter); //MOVE Right

            directions.RemoveAt(directions.Count - 1);
            lab[row, col] = '-';
        }
    }
}
