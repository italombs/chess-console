using board;
using chessGame;
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

        public static void ShowGame(ChessGame chessGame)
        {
            Console.Clear();
            PrintBoard(chessGame.Board);

            Console.WriteLine();
            Console.WriteLine("Captured pieces:");
            PrintCapturedPieces(chessGame, Color.White);
            Console.WriteLine();
            PrintCapturedPieces(chessGame, Color.Black);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Move: " + chessGame.Move);
            Console.WriteLine("Wainting player: " + chessGame.CurrentPlayerColor);

            Console.WriteLine();
            Console.Write("Enter initial position: ");
        }

        private static void PrintCapturedPieces(ChessGame chessGame, Color color)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            if (color == Color.Black)
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write(color.ToString() + ": [");

            foreach (Piece piece in chessGame.GetPiecesOutGame(color))
            {
                Console.Write(piece.ToString() + " ");
            };

            Console.Write("]");

            if (color == Color.Black)
                Console.ForegroundColor = consoleColor;
        }

        public static void PrintBoard(Board board, bool[,] possiblesMoves)
        {
            ConsoleColor actualColor = Console.ForegroundColor;

            for (int r = 0; r < board.Rows; r++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - r + " ");
                Console.ForegroundColor = actualColor;

                for (int c = 0; c < board.Columns; c++)
                {
                    if (possiblesMoves[r, c])
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    PrintPiece(board.GetPiece(r, c));
                }

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
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
            if (piece == null)
            {
                Console.Write("-");
                Console.Write(" ");
            }
            else if (piece.Color == Color.White)
                Console.Write(piece + " ");
            else if (piece.Color == Color.Black)
            {
                ConsoleColor actualColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = actualColor;
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine();

            return new ChessPosition(position[0], int.Parse(position[1].ToString()));
        }
    }
}
