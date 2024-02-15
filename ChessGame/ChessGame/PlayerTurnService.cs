using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PlayerTurnService
    {
        public bool WhitePlayerCanMove(IPawn pawn)  
        {
            if(char.IsUpper(pawn.symbol))
            return true;    

            return false;
        }

    }
}
