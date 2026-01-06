using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    public class BattleshipGame
    {
        private Player humanPlayer;
        private Player computerPlayer;

        public BattleshipGame()
        {
            humanPlayer = new Player("Human");
            computerPlayer = new Player("Computer");
        }

        public void Start()
        {
            Console.WriteLine("=== Welcome to You Sunk My Battleship! ===");
            PlaceShips(humanPlayer);
            PlaceShips(computerPlayer);

            bool isGameOver = false;
            while (!isGameOver)
            {
                isGameOver = PlayerTurn(humanPlayer, computerPlayer);
                if (isGameOver) break;

                isGameOver = PlayerTurn(computerPlayer, humanPlayer);
            }

            Console.WriteLine("Game Over!");
        }

        private void PlaceShips(Player player)
        {
            Console.WriteLine($"{player.Name}, place your ships:");
            player.PlaceShip('C', 5); // Carrier
            player.PlaceShip('B', 4); // Battleship
            player.PlaceShip('D', 3); // Destroyer
            player.PlaceShip('S', 3); // Submarine
            player.PlaceShip('P', 2); // Patrol Boat
        }

        private bool PlayerTurn(Player currentPlayer, Player opponent)
        {
            Console.Clear();
            currentPlayer.DisplayBoard();
            Console.WriteLine($"{currentPlayer.Name}'s turn!");

            bool isHit = currentPlayer.TakeShot(opponent);
            if (isHit)
            {
                Console.WriteLine("Hit!");
                if (opponent.IsFleetDestroyed())
                {
                    Console.WriteLine($"{opponent.Name}'s fleet has been destroyed!");
                    return true; // Game over
                }
            }
            else
            {
                Console.WriteLine("Miss!");
            }
            return false; // Continue the game
        }
    }
}

  
