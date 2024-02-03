using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BlackKnight : IPawn
    {
        public int rowPosition { get; set; }
        public int columnPosition { get; set; }
        public char symbol { get; } = 'n';

        public BlackKnight(int x, int y)
        {
            rowPosition = x;
            columnPosition = y;
        }
        public bool Allive()
        {
            throw new NotImplementedException();
        }

        public bool CanAttack(int x, int y)
        {
            if (CanMove(x, y))
                return true;

            return false;

        }

        public bool CanMove(int x, int y)
        {

            if (x == rowPosition && y == columnPosition)
                return false;

            if (rowPosition - 2 == x && columnPosition - 1 == y || rowPosition - 2 == x && columnPosition + 1 == y)
                return true;

            if (rowPosition + 2 == x && columnPosition + 1 == y || rowPosition + 2 == x && columnPosition - 1 == y)
                return true;

            if (rowPosition - 1 == x && columnPosition - 2 == y || rowPosition + 1 == x && columnPosition - 2 == y)
                return true;

            if (rowPosition + 1 == x && columnPosition + 2 == y || rowPosition - 1 == x && columnPosition + 2 == y)
                return true;


            return false;
        }
    }
}
