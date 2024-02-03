using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class WhitePawn : IPawn
    {

        public WhitePawn(int x, int y)
        {
            rowPosition = x;
            columnPosition = y;
        }

        public int rowPosition { get ; set ; }
        public int columnPosition { get ; set; }
        public char symbol { get; } = 'P';

        public bool Allive()
        {
            throw new NotImplementedException();
        }

        public bool CanAttack(int x, int y)
        {
            if (rowPosition - 1 == x && columnPosition + 1 == y || columnPosition - 1 == y)
                return true;

            return false;
        }

        public bool CanMove(int x, int y)
        {
            if (rowPosition == 7 && (rowPosition - 2) == x)
                return true;


            if (columnPosition != y)
                return false;

            if ((rowPosition - 1) != x)
                return false;

            if (y <= 0)
                return false;

            if (x <= 0)
                return false;


            return true;
        }
    }
}
