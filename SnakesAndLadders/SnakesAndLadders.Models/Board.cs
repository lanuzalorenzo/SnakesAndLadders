namespace SnakesAndLadders.Models
{
    public class Board
    {
        public IEnumerable<Player> Players { get; } = Enumerable.Empty<Player>();

        public IEnumerable<Square> Squares { get; } = Enumerable.Empty<Square>();

        public int InitialValue { get; set; }
        public int GoalPosition { get; set; }

        //Count of players must be defined by primary service
        //Board and squares can be defined by BD, file text, ...
        public Board(int countOfPlayers, IEnumerable<Square> squares)
        {

            var playersToAdd = new List<Player>();

            for (var i = 0; i < countOfPlayers; i++)
            {
                playersToAdd.Add(new Player()
                {
                    Id = i,
                    CurrentPosition = 1
                });
            }

            Players = playersToAdd;
            Squares = squares.OrderBy(square => square.Position);
            InitialValue = 1;
            GoalPosition = squares?.LastOrDefault()?.Position ?? default;
        }
    }
}
