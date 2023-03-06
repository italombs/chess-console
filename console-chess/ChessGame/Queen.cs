using board;
using System.Diagnostics.Eventing.Reader;

namespace chessGame
{
    internal class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board) { }

        public override bool[,] PossibleMoves()
        {
            bool[,] possiblesMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);
            //position.DefinePosition();

            return possiblesMoves;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
