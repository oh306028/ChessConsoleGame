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
        private IPawn _pawn { get; set; }
        private GridCreator _grid { get; set; }
        private int xMove { get; set; }
        private int yMove { get; set; }
        public PawnManager(IPawn pawn, GridCreator grid, MoveManager move)
        {
            _pawn = pawn;
            _grid = grid;
            xMove = move.xDirection;
            yMove = move.yDirection;
        }
                

        public void Move()
        {

            if (_pawn.CanMove(xMove, yMove))
            {
              var board = _grid.GetBoard();
                board[xMove, yMove] = _pawn.symbol;
            }
        }



    }
}
