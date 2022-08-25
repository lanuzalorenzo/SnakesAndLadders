using SnakesAndLadders.Models;
using SnakesAndLadders.MoveLibrary.Contracts;

namespace SnakesAndLadders.MoveTokenTest
{
    public class Tests
    {
        private Board _board;
        private IList<Square> _squares =  new List<Square>();
        private IMoveTokenService _moveTokenService;

        [SetUp]
        public void Setup()
        {
            for (var i = 1; i <= 20; i++)
            {
                if (i % 5 == 0)
                    _squares.Add(new Snake(i, i - 3));
                else if (i % 7 == 0)
                    _squares.Add(new Snake(i, i - 3));
                else
                    _squares.Add(new(i, i == 0, i == 20));
            }
            _board = new Board(2, _squares);
        }

        [Test]
        public void Test_StartGame()
        {
            var board = new Board(2, _squares);
            Assert.That(board.Players.All(player => player.CurrentPosition == 1), Is.True);
        }

        [Test]
        public void Test_MoveToken()
        {
            var player = _board.Players.FirstOrDefault(player => player.Id == 1);
            
            Assert.That(player, Is.Not.Null);

            var currentPosition = player.CurrentPosition;
            _moveTokenService.MoveToken(_board, 1, 3);

            Assert.That(player.CurrentPosition, Is.EqualTo(currentPosition + 3));
        }
    }
}