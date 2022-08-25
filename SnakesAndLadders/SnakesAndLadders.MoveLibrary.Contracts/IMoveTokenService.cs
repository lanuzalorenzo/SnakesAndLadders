using SnakesAndLadders.Models;

namespace SnakesAndLadders.MoveLibrary.Contracts
{
    public interface IMoveTokenService
    {
        Board StartGame();
        void MoveToken(Board board, int diceValue, int playerId);
        bool PlayerWin(Board board, int playerId);
    }
}