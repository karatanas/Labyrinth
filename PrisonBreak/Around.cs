using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Around
    {
        public static bool CheckAround(int[,] board, int x, int y)
        {
            try
            {
                if (board[y, x + 1] == TileTypes.EMPTY || board[y,x - 1] == TileTypes.EMPTY || board[y + 1, x] == TileTypes.EMPTY || board[y - 1, x] == TileTypes.EMPTY)
                {
                    return true;
                }
                else if (board[y, x + 1] == TileTypes.DOOR)
                {
                    board[y, x + 1] = TileTypes.DOORCLOSE;
                    return true;
                }
                else if (board[y, x - 1] == TileTypes.DOOR) 
                {
                    board[y, x - 1] = TileTypes.DOORCLOSE;
                    return true;
                }
                else if (board[y + 1, x] == TileTypes.DOOR)
                {
                    board[y + 1, x] = TileTypes.DOORCLOSE;
                    return true;
                }
                else if (board[y - 1, x] == TileTypes.DOOR)
                {
                    board[y - 1, x] = TileTypes.DOORCLOSE;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
       
    }
}
