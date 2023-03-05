using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece GetPiece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece GetPiece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (ExistsPiece(position))
            {
                throw new BoardException("There is already a piece in this position");
            };
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool ExistsPiece(Position position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        public bool PositionIsValid(Position position)
        {
            if (position.Row < 0 || position.Column < 0 || position.Row >= Rows || position.Column >= Columns)
                return false;

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!PositionIsValid(position))
            {
                throw new BoardException("Invalid position!");
            };
        }
    }
}
