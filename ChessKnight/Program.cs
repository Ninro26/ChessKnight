using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKnight
{
    internal class Program
    {
        static int boardSize = 8;
        static int attempedMoves = 0;

        static int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        static int[,] boardGrid = new int[boardSize, boardSize];
        static void Main(string[] args)
        {
            moveKT();
            Console.ReadLine();

        }

        static void moveKT()
        {
            //initialize all squares to not visited.
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    //setinitial value to -1`.
                    boardGrid[i, j] = -1;
                }
            }
            //intialize a starting point, number of moves.
            Console.WriteLine("Choose your starting Row.");
            int startX = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your starting Column");
            int startY = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your ending Row.");
            int endX = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your ending Column");
            int endY = int.Parse(Console.ReadLine());
            boardGrid[startX, startY] = 0;
            attempedMoves = 0;

            if (!solveKT(startX, startY, 1))
            {
                Console.WriteLine("No solution found for {0} {1}", startX, startY);
            }
            else
            {
                printBoard(boardGrid);
                Console.WriteLine("Total Attempted moves {0}", attempedMoves);
            }
            bool solveKT(int x, int y, int moveCount)
            {
                // give an update to the user.
                attempedMoves++;
                if (attempedMoves % 10000000 == 0) Console.WriteLine("Attempted {0} moves", attempedMoves);

                int k;

                int next_x, next_y; //location for the next move in recursion.

                if (moveCount == boardSize * boardSize)
                    return true;

                // cycle all the possible moves
                for (k = 0; k < 8; k++)
                {
                    next_x = x + xMove[k];
                    next_y = y + yMove[k];
                    if (safeSquare(next_x, next_y))
                    {
                        boardGrid[next_x, next_y] = moveCount;
                        if (solveKT(next_x, next_y, moveCount + 1))
                        {
                            return true;
                        }
                        else
                        {
                            boardGrid[next_x, next_y] = -1;
                        }

                    }
                   
                }
                return false;


            }
            bool safeSquare(int x, int y)
            {
                // check if x y is on board.

                return (x >= 0 && x < boardSize && y >= 0 && y < boardSize && boardGrid[x, y] == -1);

            }
            void printBoard(int[,] boardToPrint)
        {
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        if (boardGrid[i, j] < 10)
                            Console.Write(" ");
                        Console.WriteLine(boardGrid[i, j] + "");
                    }
                    Console.WriteLine();
                }
            }
        }

      
    }
} 
