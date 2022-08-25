namespace SnakesAndLadders.Models
{
    public class Ladder : Square
    {
        public int PositionToMove { get; set; }

        public Ladder() : base() { }

        public Ladder(int position, int positionToMove) : base(position, false, false)
        {
            PositionToMove = positionToMove;
        }
    }
}
