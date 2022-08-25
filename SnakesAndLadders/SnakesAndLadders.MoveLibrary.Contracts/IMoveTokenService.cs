using SnakesAndLadders.Models;

namespace SnakesAndLadders.MoveLibrary.Contracts
{
    public interface IMoveTokenService
    {
        Board StartGame();
        void MoveToken(int diceValue, int playerId);
        bool PlayerWin(int playerId);
    }
}