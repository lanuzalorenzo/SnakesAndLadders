using SnakesAndLadders.Models;

namespace SnakesAndLadders.MoveLibrary.Contracts
{
    public interface IMoveTokenService
    {
        Board StartGame(int playersCount, IEnumerable<Square> squares);
        void MoveToken(Board board, int diceValue, int playerId);
        bool PlayerWin(Board board, int playerId);
        bool IsCurrentPositionSnake(Board board, int playerId, out Snake? snakeSquare);
        bool IsCurrentPositionLadder(Board board, int playerId, out Ladder? ladderSquare);
    }
}