using System;
using System.ComponentModel;
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

                board.PutPiece(new Rook(Color.White, board), new ChessPosition('a', 1).ToPosition());
                board.PutPiece(new Rook(Color.White, board), new ChessPosition('h', 1).ToPosition());
                board.PutPiece(new Knight(Color.White, board), new ChessPosition('b', 1).ToPosition());
                board.PutPiece(new Knight(Color.White, board), new ChessPosition('g', 1).ToPosition());
                board.PutPiece(new Bishop(Color.White, board), new ChessPosition('c', 1).ToPosition());
                board.PutPiece(new Bishop(Color.White, board), new ChessPosition('f', 1).ToPosition());
                board.PutPiece(new Queen(Color.White, board), new ChessPosition('d', 1).ToPosition());
                board.PutPiece(new King(Color.White, board), new ChessPosition('e', 1).ToPosition());

                board.PutPiece(new Rook(Color.Black, board), new ChessPosition('a', 8).ToPosition());
                board.PutPiece(new Rook(Color.Black, board), new ChessPosition('h', 8).ToPosition());
                board.PutPiece(new Knight(Color.Black, board), new ChessPosition('b', 8).ToPosition());
                board.PutPiece(new Knight(Color.Black, board), new ChessPosition('g', 8).ToPosition());
                board.PutPiece(new Bishop(Color.Black, board), new ChessPosition('c', 8).ToPosition());
                board.PutPiece(new Bishop(Color.Black, board), new ChessPosition('f', 8).ToPosition());
                board.PutPiece(new Queen(Color.Black, board), new ChessPosition('d', 8).ToPosition());
                board.PutPiece(new King(Color.Black, board), new ChessPosition('e', 8).ToPosition());

                //board.PutPiece(new King(Color.White, board), new Position(0, 1));
                //board.PutPiece(new Queen(Color.White, board), new Position(1, 1));
                //board.PutPiece(new Bishop(Color.Black, board), new Position(3, 1));
                //board.PutPiece(new Pawn(Color.Black, board), new Position(4, 4));

                ChessPosition chessPosition = new ChessPosition('a', 8);

                //Console.WriteLine(chessPosition.ToPosition());

                Screen.PrintBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
