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

        public void IncreaseAmountMovies() 
        {
            AmountMovies++;
        }

        public void DecreaseAmountMovies()
        {
            AmountMovies--;
        }

        public bool HasPossiblesMoves()
        {
            bool[,] possiblesMoves = PossiblesMoves();
            for (int i = 0; i < Board.Rows; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (possiblesMoves[i, j])
                        return true;
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossiblesMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossiblesMoves();
    }
}
