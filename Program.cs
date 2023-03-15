using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTo
{
    class Program
    {
        static int player = 1, input, flag, reset = 0, count = 0;
        static string player1Input = "X";
        static string player2Input = "O";
        static string resetKey;
        static string[] grid = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static readonly string[] gridbkp = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static void Main(string[] args)
        {
            Game();
        }
        public static void drawBoard()
        {
            //Function to draw the TicTacToe Board
            Console.WriteLine("<------------------------ TIC-TAC-TOE ------------------------>");
            Console.WriteLine("Player 1: X                                      Player 2: O ");
            Console.WriteLine("Times played: {0} \n", count);
            Console.WriteLine(" " + grid[1] + " | " + grid[2] + " | " + grid[3] + " \n---|---|---\n" + " " + grid[4] + " | " + grid[5] + " | " + grid[6] + " \n---|---|---\n" + " " + grid[7] + " | " + grid[8] + " | " + grid[9] + "\n");
        }
        public static int CheckWin()
        {
            // Horizontal Region (Top, Middle and Bottom)
            if (grid[1] == grid[2] && grid[2] == grid[3])
            {
                return 1;
            }
            else if (grid[7] == grid[8] && grid[8] == grid[9])
            {
                return 1;
            }
            else if (grid[4] == grid[5] && grid[5] == grid[6])
            {
                return 1;
            }
            // Vertical Region (Left, Middle and Right)
            else if (grid[1] == grid[4] && grid[4] == grid[7])
            {
                return 1;
            }
            else if (grid[3] == grid[6] && grid[6] == grid[9])
            {
                return 1;
            }
            else if (grid[2] == grid[5] && grid[5] == grid[8])
            {
                return 1;
            }
            // Diagnols
            else if (grid[7] == grid[5] && grid[5] == grid[3])
            {
                return 1;
            }
            else if (grid[1] == grid[5] && grid[5] == grid[9])
            {
                return 1;
            }
            // Draw condition
            else if (grid[1] != "1" && grid[2] != "2" && grid[3] != "3" && grid[4] != "4" && grid[5] != "5" && grid[6] != "6" && grid[7] != "7" && grid[8] != "8" && grid[9] != "9")
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static void PlayGame()
        {
            do
            {
                // Clears the console
                Console.Clear();
                // draws a tictactoe grid onto the console
                drawBoard();
                // determines the player turn
                if (player % 2 == 1)
                {
                    Console.WriteLine("Player 1 please select a number:");
                }
                else
                {
                    Console.WriteLine("Player 2 please select a number:");
                }
                if (int.TryParse(Console.ReadLine(), out input) && input < 10 && input > 0) // Valid only when input is a number between 0 and 10
                {
                    if ((grid[input] != "X") && (grid[input] != "O")) //Valid only when the field in unoccupied by 'X' or 'O'
                    {
                        if (player % 2 == 1)
                        {
                            grid[input] = player1Input; //Replaces the field with 'X'
                            player++;                   //Increments the player turn
                        }
                        else
                        {
                            grid[input] = player2Input;  //Replaces the field with 'O'
                            player++;                    //Increments the player turn
                        }
                    }
                    else
                    {
                        Console.WriteLine("The nuber {0} is already marked with {1}", input, grid[input]);
                        Console.WriteLine("Please choose a different number:");
                    }
                }
                else
                {
                    Console.WriteLine("Value entered is invalid!\nplease try again:");
                }
                flag = CheckWin(); // Checks the winning condition
            } while (flag != 1 && flag != -1);
        }
        public static void WinState()
        {
            Console.Clear();
            drawBoard();
            if (flag == 1) // Displays the winning message
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else if (flag == -1)
            {
                Console.WriteLine("DRAW!");
            } // Displays the draw message
        }
        public static void ResetField()
        {
            Console.WriteLine("Please enter 'R' to reset the game or any other key to exit.");
            resetKey = Console.ReadLine();
            if (resetKey == "r" || resetKey == "R")
            {
                Console.WriteLine("Game resetting!");
                Console.Clear();
                gridbkp.CopyTo(grid, 0);
                reset = 1;
                count++;
            }
            else
            {
                reset = 0;
            }
        }
        public static void Game()
        {
            do
            {
                PlayGame();
                WinState();
                ResetField();
            } while (reset == 1);
        }
    }
}
