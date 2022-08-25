namespace SnakesAndLadders.Models
{
    public class Snake : Square
    {
        public int PositionToMove { get; set; }

        public Snake() : base() { }

        public Snake(int position, int positionToMove) : base(position, false, false)
        {
            PositionToMove = positionToMove;
        }
    }
}
