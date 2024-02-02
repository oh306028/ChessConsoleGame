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

        public bool ValidCordinates()
        {
            if (rowDirection > 8 || columnDirection > 8 || columnDirection <= 0 || rowDirection <= 0)
                return false;

            return true;
        }
        public int rowDirection { get; set; }
        public int columnDirection { get; set; }

    }
}
