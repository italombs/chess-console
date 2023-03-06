using board;
using System.Diagnostics.Eventing.Reader;

namespace chessGame
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board) { }
        public override bool[,] PossibleMoves()
        {
            bool[,] possiblesMoves = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            position.DefinePosition(Position.Row - 1, Position.Column);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                possiblesMoves[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != this.Color)
                    break;

                position.Row = position.Row - 1;
            }

            position.DefinePosition(Position.Row + 1, Position.Column);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                possiblesMoves[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != this.Color)
                    break;

                position.Row = position.Row + 1;
            }

            position.DefinePosition(Position.Row, Position.Column - 1);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                possiblesMoves[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != this.Color)
                    break;

                position.Column = position.Column - 1;
            }

            position.DefinePosition(Position.Row, Position.Column + 1);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                possiblesMoves[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != this.Color)
                    break;

                position.Column = position.Column + 1;
            }

            return possiblesMoves;
        }
        public bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
