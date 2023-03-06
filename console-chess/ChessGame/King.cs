using board;

namespace chessGame
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board) { }
        public override bool[,] PossibleMoves()
        {
            bool[,] possiblesMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            position.DefinePosition(Position.Row - 1, Position.Column);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row + 1, Position.Column);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row, Position.Column + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row, Position.Column - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row + 1, Position.Column + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row - 1, Position.Column - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row - 1, Position.Column + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            position.DefinePosition(Position.Row + 1, Position.Column - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
                possiblesMoves[position.Row, position.Column] = true;

            return possiblesMoves;
        }
        public bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
