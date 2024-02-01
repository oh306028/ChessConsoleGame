using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BlackPawn : IPawn
    {   
        public int positionX { get; set; }
        public int positionY { get ; set ; }
        public char symbol { get; set; } = 'p';

        public BlackPawn(int x, int y)
        {
            positionX = x;
            positionY = y;
        }

        public bool Allive()
        {
            throw new NotImplementedException();
        }

        public bool CanMove(int x, int y)
        {
            if(positionX != x)
                return false;

            if (Math.Abs(positionY - y) != 1)
                return false;

            if (y <= 0)
                return false;

            if (x <= 0)
                return false;


            return true;

        }
    }
}
