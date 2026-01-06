using System;
using System.Collections.Generic;
using System.Linq;
using _3Games;

using System;

namespace GameHub
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Welcome to the Game Hub!");

                bool continuePlaying = true;

                while (continuePlaying)
                {
                    // Choose which game to play
                    Console.WriteLine("\nChoose a game:");
                    Console.WriteLine("1. You Sunk My Battleship");
                    Console.WriteLine("2. Four in a Row");
                    Console.WriteLine("3. Tic Tac Toe");
                    Console.WriteLine("4. Exit");

                    int gameChoice;
                    if (int.TryParse(Console.ReadLine(), out gameChoice))
                    {
                        switch (gameChoice)
                        {
                            case 1:
                                BattleshipGame battleshipGame = new BattleshipGame();
                                battleshipGame.Start();
                                break;
                            case 2:
                                FourInARowGame fourInARowGame = new FourInARowGame();
                                fourInARowGame.Start();
                                break;
                            case 3:
                                TicTacToeGame ticTacToeGame = new TicTacToeGame();
                                ticTacToeGame.Start();
                                break;
                            case 4:
                                continuePlaying = false; // Exit the loop
                                continue; // Skip further prompts
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                continue; // Go back to the start of the loop
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue; // Go back to the start of the loop
                    }

                    // Ask if the user wants to play another game
                    while (true)
                    {
                        Console.WriteLine("Do you want to play another game? (y/n)");
                        string response = Console.ReadLine().Trim().ToLower();

                        if (response == "y")
                        {
                            break; // Continue outer loop
                        }
                        else if (response == "n")
                        {
                            continuePlaying = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Thank you for playing!"); // Exit message
            Console.ReadLine(); // Pause the console window
        }
    }
}






