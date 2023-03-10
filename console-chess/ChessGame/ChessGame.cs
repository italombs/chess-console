using board;
using console_chess;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace chessGame
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Move { get; private set; }
        public Color CurrentPlayerColor { get; private set; }
        public bool EndGame { get; private set; }
        private HashSet<Piece> AllPiece;
        private HashSet<Piece> PiecesOutGame;

        public ChessGame()
        {
            Board = new Board(8, 8);
            Move = 1;
            CurrentPlayerColor = Color.White;
            EndGame = false;
            AllPiece = new HashSet<Piece>();
            PiecesOutGame = new HashSet<Piece>();
            PutPieces();
        }

        private void Movement(Position initialPosition, Position finalPosition)
        {
            Piece piece = Board.RemovePiece(initialPosition);
            piece.ChangeAmountMovies();
            Piece capturedPiece = Board.RemovePiece(finalPosition);
            Board.PutPiece(piece, finalPosition);
            if (capturedPiece != null)
                PiecesOutGame.Add(capturedPiece);
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

        public void ValidateStartingPosition(Position initialPosition)
        {
            if (Board.GetPiece(initialPosition) == null)
                throw new BoardException("There is no piece in the chosen origin position!");
            if (!Board.GetPiece(initialPosition).HasPossiblesMoves())
                throw new BoardException("There are no possible moves for the chosen piece!");
            if(Board.GetPiece(initialPosition).Color != CurrentPlayerColor)
                throw new BoardException("Invalid player!");
        }

        public void ValidateDestinationPosition(Position initialPosition, Position finalPosition)
        {
            if(!Board.GetPiece(initialPosition).CanMoveTo(finalPosition))
                throw new BoardException("Invalid target position!");
        }

        private void StartPieces(Piece piece, char column, int row)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            AllPiece.Add(piece);
        }

        private void PutPieces()
        {
            char[] cls = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            StartPieces(new Rook(Color.White, Board), 'a', 1);
            StartPieces(new Rook(Color.White, Board), 'h', 1);
            StartPieces(new Knight(Color.White, Board), 'b', 1);
            StartPieces(new Knight(Color.White, Board), 'g', 1);
            StartPieces(new Bishop(Color.White, Board), 'c', 1);
            StartPieces(new Bishop(Color.White, Board), 'f', 1);
            StartPieces(new Queen(Color.White, Board), 'd', 1);
            StartPieces(new King(Color.White, Board), 'e', 1);

            //foreach (char c in cls)
            //{
            //    Board.PutPiece(new Pawn(Color.White, Board), new ChessPosition(c, 2).ToPosition());
            //}

            StartPieces(new Rook(Color.Black, Board), 'a', 8);
            StartPieces(new Rook(Color.Black, Board), 'h', 8);
            StartPieces(new Knight(Color.Black, Board), 'b', 8);
            StartPieces(new Knight(Color.Black, Board), 'g', 8);
            StartPieces(new Bishop(Color.Black, Board), 'c', 8);
            StartPieces(new Bishop(Color.Black, Board), 'f', 8);
            StartPieces(new Queen(Color.Black, Board), 'd', 8);
            StartPieces(new King(Color.Black, Board), 'e', 8);

            //foreach (char c in cls)
            //{
            //    Board.PutPiece(new Pawn(Color.Black, Board), new ChessPosition(c, 7).ToPosition());
            //}
        }

        public HashSet<Piece> GetPiecesOutGame(Color color)
        {
            HashSet<Piece> piecesOutGame = new HashSet<Piece>();

            foreach(Piece pieces in PiecesOutGame)
            {
                if (pieces.Color == color)
                    piecesOutGame.Add(pieces);
            }

            return piecesOutGame;
        }

        public HashSet<Piece> GetPiecesInGame(Color color)
        {
            HashSet<Piece> piecesInGame = new HashSet<Piece>();

            foreach (Piece pieces in AllPiece)
            {
                if (pieces.Color == color)
                    piecesInGame.Add(pieces);
            }

            piecesInGame.ExceptWith(GetPiecesOutGame(color));

            return piecesInGame;
        }

    }
}
