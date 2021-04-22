using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] gameboard = { { '_', '_', '_' }, { '_', '_', '_' }, { '_', '_', '_' } };
            Random rand = new Random();
            int xpos = 0;
            int ypos = 0;
            bool playersTurn = true;
            bool win = false;


            void showGameboard()
                {
                // Console.WriteLine("\n");
                Console.WriteLine($"{gameboard[0, 0]} {gameboard[0, 1]} {gameboard[0, 2]}");
                Console.WriteLine($"{gameboard[1, 0]} {gameboard[1, 1]} {gameboard[1, 2]}");
                Console.WriteLine($"{gameboard[2, 0]} {gameboard[2, 1]} {gameboard[2, 2]}");
                }

            void enterGameboard(int xpos, int ypos)
                {
                if (playersTurn == true)
                    gameboard[xpos, ypos] = 'X';

                if (playersTurn == false)
                    gameboard[xpos, ypos] = '0';

                }

            void whoseTurn()
                {
                if (playersTurn == true)
                    Console.WriteLine("\nIT IS THE PLAYERS TURN");

                else if (playersTurn == false)
                    Console.WriteLine("\nIT IS THE CPUs TURN");
                
                Console.WriteLine("\nCURRENT BOARD");
                showGameboard();
                }

            void cpuTurn()
                {
                whoseTurn();  // Says whose turn it is and shows the current board.

                Console.WriteLine("\nTHINKING");
                Thread.Sleep(1000);
                
                do
                {
                    xpos = rand.Next(0, 3);
                    ypos = rand.Next(0, 3);                    

                } while (gameboard[xpos, ypos] != '_');

                enterGameboard(xpos, ypos);
                Console.WriteLine("\nHERES THE CPUS MOVE");
                showGameboard();
                checkWinCondition();
                playersTurn = true; // Makes it the players turn.
                }

            void playerTurn()
                {
                
                do  // Loop to make the player choose again if that spot is already taken.
                {
                    whoseTurn();  // Says whose turn it is and shows the current board.

                    Console.WriteLine("\nEnter your move in x position");
                    xpos = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter your move in y position");
                    ypos = Convert.ToInt32(Console.ReadLine());

                    if (gameboard[xpos, ypos] != '_')   // Note telling the user that they chose an already used spot.
                    {
                        Console.WriteLine("Try that again buster!");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (gameboard[xpos, ypos] != '_');
                    enterGameboard(xpos, ypos);

                    Console.WriteLine("\nHERES THE MOVE");
                    showGameboard();
                    checkWinCondition();
                    playersTurn = false;  // Makes it not the players turn.
                                
                }
                  
            void checkWinCondition()
                {

                // X WINS CHECK

                if (gameboard[0, 0] == 'X' && gameboard[0, 1] == 'X' && gameboard[0, 2] == 'X') // 1st Row
                {   Console.WriteLine("\n\n X WINS!");  win = true; }
                if (gameboard[1, 0] == 'X' && gameboard[1, 1] == 'X' && gameboard[1, 2] == 'X') // 2nd Row
                { Console.WriteLine("\n\n X WINS!"); win = true; }
                if (gameboard[2, 0] == 'X' && gameboard[2, 1] == 'X' && gameboard[2, 2] == 'X') // 3rd Row
                { Console.WriteLine("\n\n X WINS!"); win = true; }
                if (gameboard[0, 0] == 'X' && gameboard[1, 0] == 'X' && gameboard[2, 0] == 'X') // 1st Col
                { Console.WriteLine("\n\n X WINS!"); win = true; }
                if (gameboard[0, 1] == 'X' && gameboard[1, 1] == 'X' && gameboard[2, 1] == 'X') // 2nd Col
                { Console.WriteLine("\n\n X WINS!"); win = true; }
                if (gameboard[0, 2] == 'X' && gameboard[1, 2] == 'X' && gameboard[2, 2] == 'X') // 3rd Col
                { Console.WriteLine("\n\n X WINS!"); win = true; }
                if (gameboard[0, 0] == 'X' && gameboard[1, 1] == 'X' && gameboard[2, 2] == 'X') // UL to BR Diag
                { Console.WriteLine("\n\n X WINS!"); win = true; }
                if (gameboard[0, 2] == 'X' && gameboard[1, 1] == 'X' && gameboard[2, 0] == 'X') // BL to BR Diag
                { Console.WriteLine("\n\n X WINS!"); win = true; }

                // 0 WINS CHECK

                if (gameboard[0, 0] == '0' && gameboard[0, 1] == '0' && gameboard[0, 2] == '0') // 1st Row
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[1, 0] == '0' && gameboard[1, 1] == '0' && gameboard[1, 2] == '0') // 2nd Row
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[2, 0] == '0' && gameboard[2, 1] == '0' && gameboard[2, 2] == '0') // 3rd Row
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[0, 0] == '0' && gameboard[1, 0] == '0' && gameboard[2, 0] == '0') // 1st Col
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[1, 0] == '0' && gameboard[1, 1] == '0' && gameboard[2, 1] == '0') // 2nd Col
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[0, 2] == '0' && gameboard[1, 2] == '0' && gameboard[2, 2] == '0') // 3rd Col
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[0, 0] == '0' && gameboard[1, 1] == '0' && gameboard[2, 2] == '0') // UL to BR Diag
                    Console.WriteLine("\n\n 0 WINS!");
                if (gameboard[0, 2] == '0' && gameboard[1, 1] == '0' && gameboard[2, 0] == '0') // BL to BR Diag
                    Console.WriteLine("\n\n 0 WINS!");

            }

            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Player is X, the CPU is 0");
                        
            Console.ReadKey();
            Console.Clear();

            do   // Main program loop.
            {
                
                if (playersTurn == true)
                    playerTurn();

                else if (playersTurn == false)
                    cpuTurn();

                Console.ReadKey();
                Console.Clear();
            
            } while (win == false);


        }
    }
}
