using SnakesAndLadders.Models;

namespace SnakesAndLadders.MoveLibrary.Contracts
{
    public interface IManageTurnService
    {
        bool ManagePlayerTurn(Board board, int diceValue, int playerId);
    }
}
