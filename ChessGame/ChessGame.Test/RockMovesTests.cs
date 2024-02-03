using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class RockMovesTests
    {
        [Fact]
        public void RockMoves_ForValidMoves_ReturnTrue()
        {
            //arrange

            var rock = new WhiteRock(8,1);
            var move = new MoveManager(8, 5);
            var pawnManager = new PawnManager(rock, move);


            //act
            var result = pawnManager._pawn.CanMove(move.rowDirection, move.columnDirection);


            //assert
            Assert.True(result);

        }
    }
}
