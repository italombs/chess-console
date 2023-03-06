using board;
using console_chess;
using System;
using System.Diagnostics;

namespace chessGame
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Move { get; private set; }
        public Color CurrentPlayerColor { get; private set; }
        public bool EndGame { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Move = 1;
            CurrentPlayerColor = Color.White;
            EndGame = false;
            PutPieces();
        }

        private void Movement(Position initialPosition, Position finalPosition)
        {
            Piece piece = Board.RemovePiece(initialPosition);
            piece.ChangeAmountMovies();
            Piece capturedPiece = Board.RemovePiece(finalPosition);
            Board.PutPiece(piece, finalPosition);
        }

        public void ExecuteMove(Position initialPosition, Position finalPosition)
        {
            Movement(initialPosition, finalPosition);
            Move++;

            if (CurrentPlayerColor == Color.White)
                CurrentPlayerColor = Color.Black;
            else
                CurrentPlayerColor = Color.White;
        }

        private bool StartingPostionIsValid(Position initialPosition)
        {
            if (Board.GetPiece(initialPosition) != null)
                return true;
            else
                return false;

        }

        public void ValidateStartingPosition(Position initialPosition)
        {
            if (!StartingPostionIsValid(initialPosition))
                throw new BoardException("Position has no piece!");
            if (!Board.GetPiece(initialPosition).CanPossiblesMoves())
                throw new BoardException("Piece has no possible moves!");
            if(Board.GetPiece(initialPosition).Color != CurrentPlayerColor)
                throw new BoardException("Invalid player!");
        }

        private void PutPieces()
        {
            char[] cls = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            Board.PutPiece(new Rook(Color.White, Board), new ChessPosition('a', 1).ToPosition());
            Board.PutPiece(new Rook(Color.White, Board), new ChessPosition('h', 1).ToPosition());
            Board.PutPiece(new Knight(Color.White, Board), new ChessPosition('b', 1).ToPosition());
            Board.PutPiece(new Knight(Color.White, Board), new ChessPosition('g', 1).ToPosition());
            Board.PutPiece(new Bishop(Color.White, Board), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Bishop(Color.White, Board), new ChessPosition('f', 1).ToPosition());
            Board.PutPiece(new Queen(Color.White, Board), new ChessPosition('d', 1).ToPosition());
            Board.PutPiece(new King(Color.White, Board), new ChessPosition('e', 1).ToPosition());

            //foreach (char c in cls)
            //{
            //    Board.PutPiece(new Pawn(Color.White, Board), new ChessPosition(c, 2).ToPosition());
            //}

            Board.PutPiece(new Rook(Color.Black, Board), new ChessPosition('a', 8).ToPosition());
            Board.PutPiece(new Rook(Color.Black, Board), new ChessPosition('h', 8).ToPosition());
            Board.PutPiece(new Knight(Color.Black, Board), new ChessPosition('b', 8).ToPosition());
            Board.PutPiece(new Knight(Color.Black, Board), new ChessPosition('g', 8).ToPosition());
            Board.PutPiece(new Bishop(Color.Black, Board), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new Bishop(Color.Black, Board), new ChessPosition('f', 8).ToPosition());
            Board.PutPiece(new Queen(Color.Black, Board), new ChessPosition('d', 8).ToPosition());
            Board.PutPiece(new King(Color.Black, Board), new ChessPosition('e', 8).ToPosition());

            //foreach (char c in cls)
            //{
            //    Board.PutPiece(new Pawn(Color.Black, Board), new ChessPosition(c, 7).ToPosition());
            //}
        }

    }
}
