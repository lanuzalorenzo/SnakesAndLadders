using SnakesAndLadders.Models;

namespace SnakesAndLadders.MoveLibrary.Contracts
{
    public interface IManageTurnService
    {
        void ManagePlayerTurn(Board board, int diceValue, int playerId);
    }
}
