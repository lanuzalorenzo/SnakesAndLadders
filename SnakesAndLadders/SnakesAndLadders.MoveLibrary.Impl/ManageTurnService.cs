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
            var player = board.Players.FirstOrDefault(player => player.Id == playerId);
            if (player != default)
            {
                _moveTokenService.MoveToken(board, diceValue, playerId);

                //The destination square is assumed to be neither a ladder nor a snake.
                var isSnake = _moveTokenService.IsCurrentPositionSnake(board, playerId, out var snakeSquare);
                if (isSnake && snakeSquare != default)
                    player.CurrentPosition = snakeSquare.PositionToMove;

                var isLadder = _moveTokenService.IsCurrentPositionLadder(board, playerId, out var ladderSquare);
                if (isLadder && ladderSquare != default)
                    player.CurrentPosition = ladderSquare.PositionToMove;
            }

        }
    }
}
