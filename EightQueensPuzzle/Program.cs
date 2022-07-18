using System;
using System.Collections.Generic;

namespace EightQueensPuzzle
{
    internal class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main()
        {
            var chessBoard = new bool[8, 8];

            PlaceQueen(chessBoard, 0);
        }

        private static void PlaceQueen(bool[,] chessBoard, int row)
        {
            if (row >= chessBoard.GetLength(0))
            {
                PrintChessBoard(chessBoard);
                return;
            }

            for (int col = 0; col < chessBoard.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col); //hacky way to mark diagonals occupied: leftDiagional: row - col, rightDiagonal: row + col
                    attackedRightDiagonals.Add(row + col);
                    chessBoard[row, col] = true;

                    PlaceQueen(chessBoard, row + 1);

                    //Backtracking unmark:
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col); //hacky way to mark diagonals occupied: leftDiagional: row - col, rightDiagonal: row + col
                    attackedRightDiagonals.Remove(row + col);
                    chessBoard[row, col] = false;
                }
            }
        }

        private static void PrintChessBoard(bool[,] chessBoard)
        {
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int c = 0; c < chessBoard.GetLength(1); c++)
                {
                    if (chessBoard[i, c])
                        Console.Write($"* ");
                    else
                        Console.Write($"- ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int col)
            => !attackedCols.Contains(col) &&
               !attackedRows.Contains(row) &&
               !attackedLeftDiagonals.Contains(row - col) &&
               !attackedRightDiagonals.Contains(row + col);
    }
}
