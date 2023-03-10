using board;
using console_chess;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

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
        public bool Check { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Move = 1;
            CurrentPlayerColor = Color.White;
            EndGame = false;
            AllPiece = new HashSet<Piece>();
            PiecesOutGame = new HashSet<Piece>();
            Check = false;
            PutPieces();
        }

        public void ExecuteMove(Position initialPosition, Position finalPosition)
        {
            Piece capturedPiece = Movement(initialPosition, finalPosition);

            if (InCheck(CurrentPlayerColor))
            {
                UndoMovement(capturedPiece, initialPosition, finalPosition);
                throw new BoardException("Invalid move, your king will be in check!");
            }

            if (InCheck(NextPlayerColor(CurrentPlayerColor)))
                Check = true;
            else
                Check = false;

            if (Checkmate(NextPlayerColor(CurrentPlayerColor)))
                EndGame = true;

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
            if (Board.GetPiece(initialPosition).Color != CurrentPlayerColor)
                throw new BoardException("Invalid player!");
        }

        public void ValidateDestinationPosition(Position initialPosition, Position finalPosition)
        {
            if (!Board.GetPiece(initialPosition).CanMoveTo(finalPosition))
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
            //StartPieces(new Knight(Color.White, Board), 'b', 1);
            //StartPieces(new Knight(Color.White, Board), 'g', 1);
            //StartPieces(new Bishop(Color.White, Board), 'c', 1);
            //StartPieces(new Bishop(Color.White, Board), 'f', 1);
            //StartPieces(new Queen(Color.White, Board), 'd', 1);
            StartPieces(new King(Color.White, Board), 'e', 1);

            //foreach (char c in cls)
            //{
            //    Board.PutPiece(new Pawn(Color.White, Board), new ChessPosition(c, 2).ToPosition());
            //}

            StartPieces(new Rook(Color.Black, Board), 'a', 8);
            StartPieces(new Rook(Color.Black, Board), 'h', 8);
            //StartPieces(new Knight(Color.Black, Board), 'b', 8);
            //StartPieces(new Knight(Color.Black, Board), 'g', 8);
            //StartPieces(new Bishop(Color.Black, Board), 'c', 8);
            //StartPieces(new Bishop(Color.Black, Board), 'f', 8);
            //StartPieces(new Queen(Color.Black, Board), 'd', 8);
            StartPieces(new King(Color.Black, Board), 'e', 8);

            //foreach (char c in cls)
            //{
            //    Board.PutPiece(new Pawn(Color.Black, Board), new ChessPosition(c, 7).ToPosition());
            //}
        }

        private Piece Movement(Position initialPosition, Position finalPosition)
        {
            Piece piece = Board.RemovePiece(initialPosition);
            piece.IncreaseAmountMovies();
            Piece capturedPiece = Board.RemovePiece(finalPosition);
            Board.PutPiece(piece, finalPosition);
            if (capturedPiece != null)
                PiecesOutGame.Add(capturedPiece);

            return capturedPiece;
        }

        private void UndoMovement(Piece capturedPiece, Position initialPosition, Position finalPosition)
        {
            Piece piece = Board.RemovePiece(finalPosition);
            piece.IncreaseAmountMovies();

            if (capturedPiece != null)
            {
                PiecesOutGame.Remove(capturedPiece);
                Board.PutPiece(capturedPiece, finalPosition);
            }

            Board.PutPiece(piece, initialPosition);
        }

        public HashSet<Piece> GetPiecesOutGame(Color color)
        {
            HashSet<Piece> piecesOutGame = new HashSet<Piece>();

            foreach (Piece pieces in PiecesOutGame)
            {
                if (pieces.Color == color)
                    piecesOutGame.Add(pieces);
            }

            return piecesOutGame;
        }

        private HashSet<Piece> GetPiecesInGame(Color color)
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

        public bool InCheck(Color color)
        {
            Piece king = GetKingPosition(color);

            foreach (Piece piece in GetPiecesInGame(NextPlayerColor(color)))
            {
                bool[,] possiblesMoves = piece.PossiblesMoves();

                if (possiblesMoves[king.Position.Row, king.Position.Column])
                    return true;
            }

            return false;

        }

        private bool Checkmate(Color color)
        {
            if (!Check)
            {
                return false;
            }
            else
            {
                foreach(Piece piece in GetPiecesInGame(color))
                {
                    bool[,] possiblesMoves = piece.PossiblesMoves();

                    for(int i = 0; i < Board.Rows; i++)
                    {
                        for(int j = 0; j < Board.Columns; j++)
                        {
                            if (possiblesMoves[i, j])
                            {
                                Position finalPosition = new Position(i, j);
                                Position initalPosition = piece.Position;
                                Piece capturedPiece = Movement(initalPosition, finalPosition);
                                bool inCheck = InCheck(color);
                                UndoMovement(capturedPiece, initalPosition, finalPosition);
                                if (!inCheck) 
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
        }

        private Piece GetKingPosition(Color color)
        {
            foreach (Piece piece in GetPiecesInGame(color))
            {
                if (piece is King)
                    return piece;
            }

            return null;
        }

        private Color NextPlayerColor(Color color)
        {
            if (color == Color.Black)
                return Color.White;
            else
                return Color.Black;
        }

    }
}
