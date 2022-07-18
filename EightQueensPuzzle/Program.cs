using System;

namespace EightQueensPuzzle
{
    internal class Program
    {
        static void Main()
        {
            var chessBoard = new char[8, 8];

            PlaceQueen(chessBoard, 0, 0, 0);
        }

        private static void PlaceQueen(char[,] chessBoard, int row, int col, int queensPlaced)
        {
            if (row < 0 || row >= chessBoard.GetLength(0) || col < 0 || col >= chessBoard.GetLength(1)) //We are outside the chessboard
            {
                if (col >= chessBoard.GetLength(1))
                {
                    PlaceQueen(chessBoard, row, 0, queensPlaced);
                }
                return;
            }

            if (chessBoard[row, col] == '-' || chessBoard[row, col] == '*') //The field is occupied 
            {
                PlaceQueen(chessBoard, row + 1, col + 2, queensPlaced);
                PlaceQueen(chessBoard, row + 2, col + 1, queensPlaced);
            }

            if (queensPlaced >= 8) //We have 8 queens placed
            {
                return;
            }

            chessBoard[row, col] = '*';
            queensPlaced++;
            MarkRowOccupied(chessBoard, row, col);
            MarkColOccupied(chessBoard, row, col);
            MarkRightDownDiagonalOccupied(chessBoard, row, col);
            MarkLeftDownDiagonalOccupied(chessBoard, row, col);
            MarkRightUpDiagonalOccupied(chessBoard, row, col);
            MarkLeftUpDiagonalOccupied(chessBoard, row, col);

            PlaceQueen(chessBoard, row + 1, col + 2, queensPlaced);

            PrinMatrix(chessBoard);
        }

        private static void MarkRowOccupied(char[,] chessBoard, int row, int col)
        {
            for (int chessCol = 0; chessCol < 8; chessCol++)
            {
                if (chessCol == col)
                    continue;

                if (chessBoard[row, chessCol] == '-' || chessBoard[row, chessCol] == '*')
                    continue;

                chessBoard[row, chessCol] = '-';
            }
        }

        private static void MarkColOccupied(char[,] chessBoard, int row, int col)
        {
            for (int chessRow = 0; chessRow < 8; chessRow++)
            {
                if (chessRow == row)
                    continue;

                if (chessBoard[chessRow, col] == '-' || chessBoard[chessRow, col] == '*')
                    continue;

                chessBoard[chessRow, col] = '-';
            }
        }

        private static void MarkRightDownDiagonalOccupied(char[,] chessBoard, int row, int col)
        {
            for (int chessRow = row; chessRow < 8; chessRow++)
            {
                for (int chessCol = col; chessCol < 8; chessCol++)
                {
                    if (chessRow == row + 1 && chessCol == col + 1)
                    {
                        chessBoard[chessRow, chessCol] = '-';
                        row++;
                        col++;
                    }
                }
            }
        }

        private static void MarkLeftDownDiagonalOccupied(char[,] chessBoard, int row, int col)
        {
            for (int chessRow = row; chessRow < 8; chessRow++)
            {
                for (int chessCol = col; chessCol >= 0; chessCol--)
                {
                    if (chessRow == row + 1 && chessCol == col - 1)
                    {
                        chessBoard[chessRow, chessCol] = '-';
                        row++;
                        col--;
                    }
                }
            }
        }
        private static void MarkRightUpDiagonalOccupied(char[,] chessBoard, int row, int col)
        {
            for (int chessRow = row; chessRow >= 0; chessRow--)
            {
                for (int chessCol = col; chessCol < 8; chessCol++)
                {
                    if (chessRow == row - 1 && chessCol == col + 1)
                    {
                        chessBoard[chessRow, chessCol] = '-';
                        row--;
                        col++;
                    }
                }
            }
        }

        private static void MarkLeftUpDiagonalOccupied(char[,] chessBoard, int row, int col)
        {
            for (int chessRow = row; chessRow >= 0; chessRow--)
            {
                for (int chessCol = col; chessCol >= 0; chessCol--)
                {
                    if (chessRow == row - 1 && chessCol == col - 1)
                    {
                        chessBoard[chessRow, chessCol] = '-';
                        row--;
                        col--;
                    }
                }
            }
        }

        private static void PrinMatrix(char[,] chessBoard)
        {
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int c = 0; c < chessBoard.GetLength(1); c++)
                {
                    if (chessBoard[i, c] == 0)
                    {
                        Console.Write($"  ");
                    }
                    else
                        Console.Write($" {chessBoard[i, c]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
