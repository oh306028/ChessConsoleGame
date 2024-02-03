using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class KnightMovesTests
    {
        [Theory]
        [InlineData(3,1)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(6, 4)]
        [InlineData(7, 1)]
        [InlineData(7, 3)]
    
        public void KnightMoves_ForValidMoves_ReturnsTrue(int x, int y)
        {
            //arrange

            var knight = new WhiteKnight(5, 2);
            var move = new MoveManager(x,y);
            var pawnManager = new PawnManager(knight, move);


            //act

            var result = pawnManager.MovePawn();

            //assert


            Assert.True(result);
        }

        [Theory]
        [InlineData(5,1)]
        [InlineData(6,2)]
        [InlineData(4,2)]
        [InlineData(5,3)]
        [InlineData(5,2)]
        public void KnightMoves_ForNotValidMoves_ReturnsFalse(int x, int y)
        {
            //arrange

            var knight = new WhiteKnight(5, 2);
            var move = new MoveManager(x, y);
            var pawnManager = new PawnManager(knight, move);


            //act   

            var result = pawnManager.MovePawn();

            //assert


            Assert.False(result);
        }
    }
}
