﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class WhiteRock : IPawn
    {   
        public int rowPosition { get ; set ; }
        public int columnPosition { get ; set ; }
        public char symbol { get; } = 'R';

        public WhiteRock(int x, int y)
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
            throw new NotImplementedException();
        }

        public bool CanMove(int x, int y)
        {

            if (rowPosition != x && columnPosition != y)
                return false;


            return true;

        }
    }
}
