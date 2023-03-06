namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int AmountMovies { get; protected set; } = 0;

        public Piece(Color color, Board board)
        {
            Color = color;
            Board = board;
        }

        public void ChangeAmountMovies() 
        {
            AmountMovies++;
        }

        public abstract bool[,] PossibleMoves();
    }
}
