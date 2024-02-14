using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class KingMovesOnGridTests
    {
        [Theory]
        [InlineData(5, 5)]
        [InlineData(8, 5)]
        [InlineData(8, 3)]
        [InlineData(8, 1)]
        [InlineData(1, 5)]
        [InlineData(2, 3)]
        [InlineData(7, 5)]

        public void KingMoves_ForNotValidMoves_ReturnsFalse(int x, int y)
        {
            //arrange
            bool canMove = true;
            var pawn = new WhiteKing(8, 4);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);

            //act

           if (_pawnManager._pawn.symbol == 'K' || _pawnManager._pawn.symbol == 'k')
            {
                if(!attackService.IsAttacking(board,_pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                    canMove = false;
 
            }



            //assert
            Assert.False(canMove && _pawnManager.MovePawn());

        }


        [Theory]
        [InlineData(7, 4)]
        [InlineData(8, 3)]

        public void KingMoves_ForValidMoves_ReturnsTrue(int x, int y)   
        {
            //arrange
            bool canMove = true;
            var pawn = new WhiteKing(8, 4);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);

            board[7, 4] = ' ';
            board[8, 3] = ' ';


            //act

            if (_pawnManager._pawn.symbol == 'K' || _pawnManager._pawn.symbol == 'k')
            {
                if (!attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                    canMove = false;

            }



            //assert
            Assert.True(canMove && _pawnManager.MovePawn());


        }
    }

}
