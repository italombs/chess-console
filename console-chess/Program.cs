using System;
using board;
using chessGame;
using ChessGame;

namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new King(Color.White, board), new Position(0, 1));
                board.PutPiece(new Queen(Color.White, board), new Position(1, 1));
                board.PutPiece(new Bishop(Color.White, board), new Position(3, 1));
                board.PutPiece(new Pawn(Color.White, board), new Position(4, 4));

                ChessPosition chessPosition = new ChessPosition('a', 8);

                Console.WriteLine(chessPosition.ToPosition());

                Screen.PrintBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
