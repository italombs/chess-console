namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int AmountMovies { get; protected set; } = 0;

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
        }
    }
}
