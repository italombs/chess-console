using board;
using System;

namespace console_chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            ConsoleColor actualColor = Console.ForegroundColor;

            for (int r = 0; r < board.Rows; r++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - r + " ");
                Console.ForegroundColor = actualColor;



                for (int c = 0; c < board.Columns; c++)
                {
                    if (board.GetPiece(r, c) == null)
                        Console.Write("-" + " ");
                    else
                        PrintPiece(board.GetPiece(r, c));
                }

                Console.WriteLine();
            }



            string cls = "a,b,c,d,e,f,g,h";
            string[] columns = cls.Split(',');
            Console.Write(" ");
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Red;

            foreach (string column in columns)
            {
                Console.Write(column);
                Console.Write(" ");
            }

            Console.WriteLine("");

            Console.ForegroundColor = actualColor;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
                Console.Write(piece + " ");
            else if(piece.Color == Color.Black)
            {
                ConsoleColor actualColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = actualColor;
            }
        }
    }
}
