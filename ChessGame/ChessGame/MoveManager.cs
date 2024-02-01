using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class MoveManager
    {
        public MoveManager(int x, int y)
        {
            xDirection = x;
            yDirection = y;
        }
        public int xDirection { get; set; }
        public int yDirection { get; set; }

    }
}
