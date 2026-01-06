using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    public class FourInARowGame
    {
        private readonly int rows = 6, cols = 7;
        private char[,] board;
        private char currentPlayer;

        public FourInARowGame()
        {
            board = new char[rows, cols];
            currentPlayer = 'X';
            InitializeBoard();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Four in a Row!");
            bool gameOver = false;

            while (!gameOver)
            {
                DisplayBoard();
                PlayerTurn();
                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"{currentPlayer} wins!");
                    gameOver = true;
                    break;
                }
                SwitchPlayer();

                ComputerTurn();
                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"{currentPlayer} wins!");
                    gameOver = true;
                    break;
                }
                SwitchPlayer();
            }
        }

        private void InitializeBoard()
        {
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    board[r, c] = '.';
        }

        private void DisplayBoard()
        {
            Console.Clear();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                    Console.Write(board[r, c] + " ");
                Console.WriteLine();
            }
        }

        private void PlayerTurn()
        {
            int col;
            Console.WriteLine("Your turn: Choose a column (1-7):");
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out col) && col >= 1 && col <= cols)
                {
                    col--;
                    if (DropPiece(col, currentPlayer))
                        break;
                    else
                        Console.WriteLine("Column is full, try another.");
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }

        private void ComputerTurn()
        {
            Console.WriteLine("Computer's turn...");
            Random rand = new Random();
            int col;
            do
            {
                col = rand.Next(0, cols);
            } while (!DropPiece(col, currentPlayer));
        }

        private bool DropPiece(int col, char player)
        {
            for (int row = rows - 1; row >= 0; row--)
            {
                if (board[row, col] == '.')
                {
                    board[row, col] = player;
                    return true;
                }
            }
            return false;
        }

        private bool CheckWin()
        {
            // Horizontal, vertical, diagonal checks
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (board[r, c] != '.' &&
                        (CheckLine(r, c, 0, 1) || CheckLine(r, c, 1, 0) || CheckLine(r, c, 1, 1) || CheckLine(r, c, 1, -1)))
                        return true;
                }
            }
            return false;
        }

        private bool CheckLine(int row, int col, int dRow, int dCol)
        {
            char player = board[row, col];
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int r = row + i * dRow;
                int c = col + i * dCol;
                if (r >= 0 && r < rows && c >= 0 && c < cols && board[r, c] == player)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count == 4;
        }

        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }

}
