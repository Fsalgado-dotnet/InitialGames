using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    public class Player
    {
        public string Name { get; private set; }
        private Board board;

        public Player(string name)
        {
            Name = name;
            board = new Board();
        }

        public void DisplayBoard()
        {
            board.Display();
        }

        public void PlaceShip(char type, int size)
        {
            bool placed = false;
            while (!placed)
            {
                Console.Write($"Place ship '{type}' (size {size}) - Enter start position (e.g., A1) and orientation (H/V): ");
                string input = Console.ReadLine();
                var parts = input.Split(' ');

                if (parts.Length == 2 && parts[0].Length >= 2)
                {
                    int row = int.Parse(parts[0][1..]) - 1; // Convert to 0-based index
                    int col = parts[0][0] - 'A'; // Convert column letter to index
                    Orientation orientation = parts[1].ToUpper() == "H" ? Orientation.Horizontal : Orientation.Vertical;

                    placed = board.PlaceShip(type, size, row, col, orientation);
                    if (!placed)
                    {
                        Console.WriteLine("Invalid placement. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input format. Try again.");
                }
            }
        }

        public bool TakeShot(Player opponent)
        {
            Console.Write("Enter your shot (e.g., A1): ");
            string input = Console.ReadLine();
            int row = int.Parse(input[1..]) - 1; // Convert to 0-based index
            int col = input[0] - 'A'; // Convert column letter to index

            return opponent.board.ReceiveShot(row, col);
        }

        public bool IsFleetDestroyed()
        {
            return board.AreAllShipsSunk();
        }
    }
}

