using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BlackQueen : IPawn
    {
        public int rowPosition { get; set; }
        public int columnPosition { get; set; }

        public char symbol { get; } = 'q';

        public BlackQueen(int x, int y)
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

            if (rowPosition == x && columnPosition == y)
                return false;

            if (rowPosition != x && columnPosition == y || rowPosition == x && columnPosition != y)
                return true;


            if (Math.Abs(rowPosition - x) == Math.Abs(columnPosition - y))
                return true;


            return false;
        }
    }
}
