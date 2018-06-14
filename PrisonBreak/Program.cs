using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Program
    {
        public static Random rand = new Random(DateTime.Now.Millisecond);
        public static readonly int BOARD_SIZE = 10;
        public static int[,] board;
        public static int startX, startY;

        public static void printMaze()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            char[,] boardChar = new char[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i,j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0} ", board[i, j]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (board[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", board[i, j]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.Write("{0} ", board[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Do you want to create and pass a labyrinth ? (Yes / No)");
                Console.ResetColor();
                string check1 = Console.ReadLine();
                if (check1 == "Yes" || check1 == "yes")
                {
                    // Get random board
                    board = PrisonBreakTools.getNewMaze(BOARD_SIZE, rand);
                    do
                    {
                        startX = rand.Next(0, BOARD_SIZE);
                        startY = rand.Next(0, BOARD_SIZE);                 
                    }
                    while (board[startX, startY] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE - 1 || startY == BOARD_SIZE - 1);
                    Console.WriteLine("\nStart: " + startX + " " + startY+"\n");

                    // Your output goes here
                    
                    int x = startX; int y = startY;
                    int X; int Y;
                    board[y, x] = TileTypes.MOVE;
                    Stack lastXY = new Stack();                   
                    printMaze();
                    while (x > 0 || y > 0 || x < BOARD_SIZE - 1 || y < BOARD_SIZE - 1)
                    {
                        if (Around.CheckAround(board, x, y))
                        {
                            lastXY.Push(x); lastXY.Push(y);
                            X = x; Y = y;
                            Step.OneStep(board, x, y, out X, out Y);
                            x = X; y = Y;
                        }
                        else if (!Around.CheckAround(board, x, y))
                        {
                            if (!Around.CheckAround(board, x, y) && (x == 0 || y == 0 || x == BOARD_SIZE - 1 || y == BOARD_SIZE - 1))
                            {
                                Console.WriteLine();
                                printMaze();
                                Console.WriteLine("Labyrinth is overcome\n");
                                Console.ForegroundColor = ConsoleColor.DarkGray; 
                                Console.WriteLine("Start: " + startX + " " + startY);
                                Console.WriteLine("Exit: " + x + " " + y+"\n");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                            try
                            {
                                y = Convert.ToInt32(lastXY.Peek());
                                lastXY.Pop();
                                x = Convert.ToInt32(lastXY.Peek());
                                lastXY.Pop();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine();
                                printMaze();
                                Console.WriteLine("Labyrinth is overcome\n");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Start: " + startX + " " + startY);
                                Console.WriteLine("No exit(\n");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No exit\n");
                            System.Threading.Thread.Sleep(2000);
                            break;
                        }
                    }
                }
                else if(check1=="No" || check1=="no")
                {
                    Console.WriteLine();
                    Console.WriteLine("The program does not work at 100%, but I tried very hard)");
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Bye..");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Console.ReadKey();
        }
    }
}

