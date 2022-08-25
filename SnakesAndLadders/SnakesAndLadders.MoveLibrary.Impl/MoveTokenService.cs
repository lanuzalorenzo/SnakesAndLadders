using SnakesAndLadders.Models;
using SnakesAndLadders.MoveLibrary.Contracts;

namespace SnakesAndLadders.MoveLibrary.Impl
{
    public class MoveTokenService : IMoveTokenService
    {
        public void MoveToken(Board board, int diceValue, int playerId)
        {
            var currentPlayer = board?.Players?.FirstOrDefault(player => playerId == player.Id);
            if (currentPlayer == default)
                throw new ArgumentException("Parameters are not valid.");

            currentPlayer.CurrentPosition += diceValue;
            if (currentPlayer.CurrentPosition > (board?.GoalPosition ?? default))
                currentPlayer.CurrentPosition = (board?.GoalPosition ?? default);
        }

        public bool PlayerWin(Board board, int playerId)
        {
            throw new NotImplementedException();
        }

        public Board StartGame(int playersCount, IEnumerable<Square> squares) => new Board(playersCount, squares);
    }
}