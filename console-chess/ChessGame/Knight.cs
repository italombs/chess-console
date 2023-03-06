using board;

namespace chessGame
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board) { }
        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "N";
        }
    }
}
