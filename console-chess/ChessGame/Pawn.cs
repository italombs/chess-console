using board;

namespace chessGame
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board) { }
        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
