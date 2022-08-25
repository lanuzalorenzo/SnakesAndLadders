using SnakesAndLadders.Models;
using SnakesAndLadders.MoveLibrary.Contracts;
using SnakesAndLadders.MoveLibrary.Impl;

namespace SnakesAndLadders.MoveTokenTest
{
    public class Tests
    {
        private Board _board;
        private readonly IList<Square> _squares = new List<Square>();
        private IMoveTokenService _moveTokenService;
        private IManageTurnService _manageTurn;

        [SetUp]
        public void Setup()
        {
            for (var i = 1; i <= 20; i++)
            {
                if (i % 5 == 0 && i != 20)
                    _squares.Add(new Snake(i, i - 3));
                else if (i % 7 == 0)
                    _squares.Add(new Ladder(i, i + 4));
                else
                    _squares.Add(new(i, i == 0, i == 20));
            }
            _board = new Board(2, _squares);
            _moveTokenService = new MoveTokenService();

            //MoveNextService inyection should be a mock
            _manageTurn = new ManageTurnService(_moveTokenService);
        }

        [Test]
        public void Test_StartGame()
        {
            var board = new Board(2, _squares);
            Assert.That(board.Players.All(player => player.CurrentPosition == 1), Is.True);
        }

        [Test]
        public void Test_MoveTokenWithOutSnakeOrLadder()
        {
            var player = _board.Players.FirstOrDefault(player => player.Id == 1);

            Assert.That(player, Is.Not.Null);

            var currentPosition = player.CurrentPosition;
            _moveTokenService.MoveToken(_board, 3, 1);

            Assert.That(player.CurrentPosition, Is.EqualTo(currentPosition + 3));
        }


        [Test]
        public void Test_PlayerNotExists()
        {
            Assert.Throws<ArgumentException>(() => _moveTokenService.MoveToken(_board, 3, 5));
        }

        [Test]
        public void Test_MoveTokenWithSnake()
        {
            var player = _board.Players.FirstOrDefault(player => player.Id == 1);

            Assert.That(player, Is.Not.Null);

            _manageTurn.ManagePlayerTurn(_board, 4, 1);
            Assert.That(player.CurrentPosition, Is.EqualTo(2));
        }

        [Test]
        public void Test_MoveTokenWithLadder()
        {
            var player = _board.Players.FirstOrDefault(player => player.Id == 1);

            Assert.That(player, Is.Not.Null);

            _manageTurn.ManagePlayerTurn(_board, 6, 1);
            Assert.That(player.CurrentPosition, Is.EqualTo(11));
        }

        [Test]
        public void Test_PlayerWins()
        {
            _manageTurn.ManagePlayerTurn(_board, 6, 1);
            
            //Position 11
            _manageTurn.ManagePlayerTurn(_board, 6, 1);
            
            //Position 17
            Assert.IsTrue(_manageTurn.ManagePlayerTurn(_board, 3, 1));
        }

        [Test]
        public void Test_FinalSquareMustNotBeSnake()
        {
            Assert.That(_board.Squares.LastOrDefault() is Snake, Is.False);
        }


        [Test]
        public void Test_FinalSquareMustNotBeLadder()
        {
            Assert.That(_board.Squares.LastOrDefault() is Ladder, Is.False);
        }
    }
}