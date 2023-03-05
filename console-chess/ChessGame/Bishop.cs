using board;

namespace chessGame
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board) { }

        public override string ToString()
        {
            return "B";
        }
    }
}
