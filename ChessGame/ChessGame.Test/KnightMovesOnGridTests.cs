using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class KnightMovesOnGridTests
    {
        [Theory]
        [InlineData(7, 4)]
        [InlineData(6, 3)]
        [InlineData(6, 1)]
      
        public void KnightValidationMoves_ForNotValidMoves_ReturnFalse(int x, int y)
        {
            //arrange
            bool canMove = true;
            var pawn = new WhiteKnight(8, 2);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);

            board[6, 1] = 'P';
            board[6, 3] = 'P';

            //act
            if (_pawnManager._pawn.symbol == 'N' || _pawnManager._pawn.symbol == 'n')
            {
                if (_pawnManager.MovePawn())
                {
                    if (!attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        canMove = false;
                }

            }




            //assert
            Assert.False(canMove);

        }
        [Theory]
        [InlineData(6, 1)]
        [InlineData(6, 3)]


        public void KnightValidationMoves_ForValidMoves_ReturnTrue(int x, int y)
        {   
            //arrange
            bool canMove = true;
            var pawn = new WhiteKnight(8, 2);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);


            //act
            if (_pawnManager._pawn.symbol == 'N' || _pawnManager._pawn.symbol == 'n')
            {
                if (_pawnManager.MovePawn())
                {
                    if(!attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        canMove = false;
                }

                    

            }


            //assert
            Assert.True(canMove);

        }

    }
}
