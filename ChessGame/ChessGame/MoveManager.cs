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
            rowDirection = x;
            columnDirection = y;
        }
        public int rowDirection { get; set; }
        public int columnDirection { get; set; }

    }
}
