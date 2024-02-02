using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PawnManager
    {
        public IPawn _pawn { get; set; }
        public int rowMove { get; set; }
        public int columnMove { get; set; }

        public PawnManager(IPawn pawn, MoveManager move)
        {
            _pawn = pawn;        
            rowMove = move.rowDirection;
            columnMove = move.columnDirection;
        }
                

        public bool MovePawn()
        {
            if (_pawn.CanMove(rowMove, columnMove))
                return true;

            return false;

        }


    }
}
