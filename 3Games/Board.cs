using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    public class Board
    {
        private const int Size = 10;
        private char[,] grid;
        private List<Ship> ships;

        public Board()
        {
            grid = new char[Size, Size];
            ships = new List<Ship>();
            Initialize();
        }

        private void Initialize()
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    grid[r, c] = '~'; // Water symbol
        }

        public bool PlaceShip(char type, int size, int startRow, int startCol, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                if (startCol + size > Size) return false;
                for (int c = startCol; c < startCol + size; c++)
                {
                    if (grid[startRow, c] != '~') return false; // Overlap
                }
                List<Point> coordinates = new List<Point>();
                for (int c = startCol; c < startCol + size; c++)
                {
                    grid[startRow, c] = type;
                    coordinates.Add(new Point(startRow, c));
                }
                ships.Add(new Ship(type, size, coordinates));
                return true;
            }
            else
            {
                if (startRow + size > Size) return false;
                for (int r = startRow; r < startRow + size; r++)
                {
                    if (grid[r, startCol] != '~') return false; // Overlap
                }
                List<Point> coordinates = new List<Point>();
                for (int r = startRow; r < startRow + size; r++)
                {
                    grid[r, startCol] = type;
                    coordinates.Add(new Point(r, startCol));
                }
                ships.Add(new Ship(type, size, coordinates));
                return true;
            }
        }

        public bool ReceiveShot(int row, int col)
        {
            if (row < 0 || row >= Size || col < 0 || col >= Size) return false;

            if (grid[row, col] == '~')
            {
                grid[row, col] = 'O'; // Miss
                return false;
            }
            else if (grid[row, col] != 'X' && grid[row, col] != 'O')
            {
                grid[row, col] = 'X'; // Hit
                Ship hitShip = ships.FirstOrDefault(s => s.Coordinates.Any(p => p.Row == row && p.Col == col));
                if (hitShip != null)
                {
                    hitShip.RegisterHit(new Point(row, col));
                }
                return true;
            }
            return false; // Already hit or missed
        }

        public bool AreAllShipsSunk()
        {
            return ships.All(s => s.IsSunk());
        }

        public void Display()
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int r = 0; r < Size; r++)
            {
                Console.Write((r + 1).ToString().PadLeft(2) + " ");
                for (int c = 0; c < Size; c++)
                {
                    Console.Write(grid[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}
