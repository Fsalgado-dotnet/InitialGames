using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    public class TicTacToeGame
    {
        private char[,] board;
        private char currentPlayer;
        private const int Size = 3;

        public TicTacToeGame()
        {
            board = new char[Size, Size];
            currentPlayer = 'X';
        }

        public void Start()
        {
            InitializeBoard(); // Initialize the board for each new game
            currentPlayer = 'X'; // Reset player
            Console.WriteLine("Welcome to Tic Tac Toe!");

            while (true)
            {
                DisplayBoard();
                PlayerTurn();
                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"{currentPlayer} wins!");
                    break;
                }
                else if (IsFull())
                {
                    DisplayBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }
                SwitchPlayer();
                ComputerTurn();
                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"{currentPlayer} wins!");
                    break;
                }
                SwitchPlayer();
            }

            Console.WriteLine("Game over! Press any key to return to the main menu.");
            Console.ReadKey(true); // wait for key press without displaying it
        }

        private void InitializeBoard()
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    board[r, c] = '.';
        }

        private void DisplayBoard()
        {
            Console.Clear();
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                    Console.Write(board[r, c] + " ");
                Console.WriteLine();
            }
        }

        private void PlayerTurn()
        {
            int row, col;
            Console.WriteLine("Your turn: Enter row and column (e.g. 1,1):");
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == null) continue;
                var parts = input.Split(',');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out row) &&
                    int.TryParse(parts[1], out col) &&
                    row >= 1 && row <= Size && col >= 1 && col <= Size &&
                    board[row - 1, col - 1] == '.')
                {
                    board[row - 1, col - 1] = currentPlayer;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input or cell taken, try again.");
                }
            }
        }

        private void ComputerTurn()
        {
            Console.WriteLine("Computer's turn...");
            Random rand = new Random();
            while (true)
            {
                int row = rand.Next(0, Size);
                int col = rand.Next(0, Size);
                if (board[row, col] == '.')
                {
                    board[row, col] = currentPlayer;
                    break;
                }
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < Size; i++)
            {
                // Rows and columns
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                    return true;
            }

            // Diagonals
            return (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                   (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer);
        }

        private bool IsFull()
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (board[r, c] == '.')
                        return false;
            return true;
        }

        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}




