using SnakesAndLadders.Models;
using SnakesAndLadders.MoveLibrary.Contracts;

namespace SnakesAndLadders.MoveLibrary.Impl
{
    public class MoveTokenService : IMoveTokenService
    {
        public bool IsCurrentPositionSnake(Board board, int playerId, out Snake? snakeSquare)
        {
            var currentPlayer = board?.Players?.FirstOrDefault(player => playerId == player.Id);
            if (currentPlayer == default)
                throw new ArgumentException("Parameters are not valid.");

            var square = board?.Squares?.FirstOrDefault(square => square.Position == currentPlayer.CurrentPosition);
            if (square == default)
                throw new ArgumentException("Parameters are not valid.");

            if(square is Snake)
            {
                snakeSquare = (Snake)square;
                return true;
            }
            snakeSquare = default;
            return false;
        }

        public bool IsCurrentPositionLadder(Board board, int playerId, out Ladder? ladderSquare)
        {
            var currentPlayer = board?.Players?.FirstOrDefault(player => playerId == player.Id);
            if (currentPlayer == default)
                throw new ArgumentException("Parameters are not valid.");

            var square = board?.Squares?.FirstOrDefault(square => square.Position == currentPlayer.CurrentPosition);
            if (square == default)
                throw new ArgumentException("Parameters are not valid.");

            if (square is Ladder)
            {
                ladderSquare = (Ladder)square;
                return true;
            }
            ladderSquare = default;
            return false;
        }

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
            var currentPlayer = board?.Players?.FirstOrDefault(player => playerId == player.Id);
            if (currentPlayer == default || board == default)
                throw new ArgumentException("Parameters are not valid.");

            return board.GoalPosition == currentPlayer.CurrentPosition;
        }

        public Board StartGame(IEnumerable<int> playersList, IEnumerable<Square> squares) {
            var board = new Board(playersList, squares);
            if (board.Squares.LastOrDefault() is Snake)
                throw new ArgumentException("Last square must not be snake");
            else if (board.Squares.LastOrDefault() is Ladder)
                throw new ArgumentException("Last square must not be Ladder");
            else if (board.Squares.FirstOrDefault() is Snake)
                throw new ArgumentException("First square must not be snake");
            else if (board.Squares.FirstOrDefault() is Ladder)
                throw new ArgumentException("First square must not be Ladder");

            else return board;
        }
    }
}