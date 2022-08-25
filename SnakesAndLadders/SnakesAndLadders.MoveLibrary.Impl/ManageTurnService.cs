using SnakesAndLadders.Models;
using SnakesAndLadders.MoveLibrary.Contracts;

namespace SnakesAndLadders.MoveLibrary.Impl
{
    public class ManageTurnService : IManageTurnService
    {
        private readonly IMoveTokenService _moveTokenService;

        public ManageTurnService(IMoveTokenService moveTokenService)
        {
            _moveTokenService = moveTokenService;
        }

        public void ManagePlayerTurn(Board board, int diceValue, int playerId)
        {
            _moveTokenService.MoveToken(board, diceValue, playerId);

            var isSnake = _moveTokenService.IsCurrentPositionSnake(board, playerId, out var snakeSquare);
            if (isSnake)
            {
                var player = board.Players.FirstOrDefault(player => player.Id == playerId);
                if (player != default && snakeSquare != default)
                    player.CurrentPosition = snakeSquare.PositionToMove;
            }
        }
    }
}
