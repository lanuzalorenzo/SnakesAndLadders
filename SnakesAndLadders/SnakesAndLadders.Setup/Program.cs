// See https://aka.ms/new-console-template for more information
using SnakesAndLadders.Models;
using SnakesAndLadders.MoveLibrary.Impl;

namespace SnakesAndLadders.Setup // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playersCount = 3;
            //Must be dependency inyection
            var moveTokenService = new MoveTokenService();
            var manageTurnService = new ManageTurnService(moveTokenService);

            //Must obtanied by BD, Json, text file, ...
            var squares = new List<Square>();
            for (var i = 1; i <= 20; i++)
            {
                if (i % 5 == 0 && i != 20)
                    squares.Add(new Snake(i, i - 3));
                else if (i % 7 == 0)
                    squares.Add(new Ladder(i, i + 4));
                else
                    squares.Add(new(i, i == 0, i == 20));
            }

            var playersList = new List<int>();

            for (var i = 0; i < playersCount; i++)
                playersList.Add(i);

            var board = moveTokenService.StartGame(playersList, squares);
            

            var anyPlayerWin = false;
            var turn = 0;
            while (!anyPlayerWin)
            {
                Console.WriteLine($"Turn {turn}");
                foreach(var player in playersList)
                {
                    
                    var seed = Environment.TickCount;
                    var random = new Random(seed);
                    var dice = random.Next(1, 6);

                    Console.WriteLine($"Player {player}. StartsTurn. Position {board.Players.FirstOrDefault(playerData => playerData.Id == player)?.CurrentPosition}. Dice {dice}");

                    var isWinPlayer = manageTurnService.ManagePlayerTurn(board, dice, player);
                    Console.WriteLine($"Player {player}. End turn. Position {board.Players.FirstOrDefault(playerData => playerData.Id == player)?.CurrentPosition}");

                    if (isWinPlayer)
                    {
                        Console.WriteLine($"Player {player} wins");
                        anyPlayerWin = true;
                        break;
                    }
                }
            }
        }
    }
}