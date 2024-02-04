using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class BishopMovesTests
    {
        [Theory]
        [InlineData(5,3)]
        [InlineData(2, 3)]
        [InlineData(4, 3)]
        [InlineData(7, 3)]
        [InlineData(6, 1)]
        public void BishopMove_ForNotValidMoves_ReturnsTrue(int x, int y)
        {
            //arrange   
            var gridCreator = new GridCreator();
            var board = gridCreator.InitGrid();
           
            var piece = new WhiteBishop(8,3);
            var moves = new MoveManager(x, y);


            var pawnManager = new PawnManager(piece, moves);
            var gridManager = new GridManager(pawnManager);

            //act
            gridManager.ChangeBoardAfterChange(ref board);
            var result = board[x, y] != piece.symbol;
            //assert

            Assert.True(result);
        }
    }
}
