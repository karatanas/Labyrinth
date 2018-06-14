using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Step
    {
        public static Random rand = new Random();
        public static void OneStep(int[,] board, int x, int y, out int X, out int Y)
        {
            X = x; Y = y;
            int randProb = rand.Next(1,5);
            try
            {
                if (randProb == 1 && (board[Y, X + 1] == TileTypes.WALL || board[Y, X + 1] == TileTypes.MOVE))
                {
                    if(board[Y, X + 1] == TileTypes.DOOR)
                    {
                        board[Y, X + 1] = TileTypes.DOORCLOSE;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (randProb == 2 && (board[Y, X - 1] == TileTypes.WALL || board[Y, X - 1] == TileTypes.MOVE))
                {
                    if (board[Y, X - 1] == TileTypes.DOOR)
                    {
                        board[Y, X - 1] = TileTypes.DOORCLOSE;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (randProb == 3 && (board[Y + 1, X] == TileTypes.WALL || board[Y + 1, X] == TileTypes.MOVE))
                {
                    if (board[Y + 1, X] == TileTypes.DOOR)
                    {
                        board[Y + 1, X] = TileTypes.DOORCLOSE;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (randProb == 4 && (board[Y - 1, X] == TileTypes.WALL || board[Y - 1, X] == TileTypes.MOVE))
                {
                    if (board[Y - 1, X] == TileTypes.DOOR)
                    {
                        board[Y - 1, X] = TileTypes.DOORCLOSE;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            switch (randProb)
            {
                case 1:
                    if(board[Y, X] == TileTypes.DOOR)
                    {
                        X++;
                        board[Y, X] = TileTypes.DOORCLOSE;
                        break;
                    }
                    else if(board[Y, X] == TileTypes.DOORCLOSE)
                    {
                        break;
                    }
                    else
                    {
                        X++;
                        board[Y, X] = TileTypes.MOVE;
                        break;
                    }
                case 2:
                    if (board[Y, X] == TileTypes.DOOR)
                    {
                        X--;
                        board[Y, X] = TileTypes.DOORCLOSE;
                        break;
                    }
                    else if (board[Y, X] == TileTypes.DOORCLOSE)
                    {
                        break;
                    }
                    else
                    {
                        X--;
                        board[Y, X] = TileTypes.MOVE;
                        break;
                    }
                case 3:
                    if (board[Y, X] == TileTypes.DOOR)
                    {
                        Y++;
                        board[Y, X] = TileTypes.DOORCLOSE;
                        break;
                    }
                    else if (board[Y, X] == TileTypes.DOORCLOSE)
                    {
                        break;
                    }
                    else
                    {
                        Y++;
                        board[Y, X] = TileTypes.MOVE;
                        break;
                    }
                case 4:
                    if (board[Y, X] == TileTypes.DOOR)
                    {
                        Y--;
                        board[Y, X] = TileTypes.DOORCLOSE;
                        break;
                    }
                    else if (board[Y, X] == TileTypes.DOORCLOSE)
                    {
                        break;
                    }
                    else
                    {
                        Y--;
                        board[Y, X] = TileTypes.MOVE;
                        break;
                    }
                default: break;
            }

        

            x = X; y = Y;
        }
    }
}
