using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class PawnMovesOnGridTests
    {
        [Fact]
        public void PawnMoves_ForNotValid_ReturnsFalse()
        {
            bool canMove = true;
            var grid = new GridCreator();
            var board = grid.InitGrid();

            board[4, 4] = 'p';
            board[5, 4] = 'P';

            var pawn = new WhitePawn(5, 4);
            var move = new MoveManager(4, 4);
            var _pawnManager = new PawnManager(pawn, move);
           
            
            var attackService = new PieceAttacksService(pawn);
            var gridManager = new GridManager(_pawnManager);


            canMove = gridManager.CheckBoardBeforeChange(board);




            Assert.False(canMove && _pawnManager.MovePawn());


        }
    }
}
