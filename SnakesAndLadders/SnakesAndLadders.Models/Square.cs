namespace SnakesAndLadders.Models
{
    public class Square
    {
        public int Position { get; set; }
        public bool IsInitial { get; set; }
        public bool IsGoal { get; set; }

        public Square() { }

        public Square(int position, bool isInitial, bool isGoal)
        {
            Position = position;
            IsInitial = isInitial;
            IsGoal = isGoal;
        }
    }
}