using board;

namespace chessGame
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board) { }
        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
