using board;
using System;

namespace console_chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int r = 0; r < board.Rows; r++)
            {
                for (int c = 0; c < board.Columns; c++)
                {
                    if (board.GetPiece(r, c) == null)
                        Console.Write("-" + " ");
                    else
                        Console.Write(board.GetPiece(r, c) + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
