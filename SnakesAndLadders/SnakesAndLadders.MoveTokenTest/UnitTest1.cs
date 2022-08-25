using SnakesAndLadders.Models;

namespace SnakesAndLadders.MoveTokenTest
{
    public class Tests
    {
        private Board _board;
        private IList<Square> _squares;

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
        public void Test1()
        {
            Assert.Pass();
        }
    }
}