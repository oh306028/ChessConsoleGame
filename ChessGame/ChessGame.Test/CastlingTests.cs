using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class CastlingTests
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(1, 8)]
        public void Castling_ForNotValidMoves_ReturnFalse(int x, int y) 
        {
            bool canMove = true;
            var pawn = new BlackKing(1, 5);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var gridMan = new GridManager(_pawnManager);



            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.False(canMove);
        }



        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 8)]
        public void Castling_ForNotValidMoves_ReturnTrue(int x, int y)
        {
            bool canMove = true;
            var grid = new GridCreator();
            var board = grid.InitGrid();
            board[1, 2] = ' ';
            board[1, 3] = ' ';
            board[1, 4] = ' ';
            board[1, 6] = ' ';
            board[1, 7] = ' ';
            var pawn = new BlackKing(1, 5);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var gridMan = new GridManager(_pawnManager);



            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.True(canMove);
        }


        [Theory]
        [InlineData(8, 1)]
        [InlineData(8, 8)]
        public void Castling_ForNotValidMoves_ReturnFalse2(int x, int y)    
        {
            bool canMove = true;
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var pawn = new WhiteKing(8, 4);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var gridMan = new GridManager(_pawnManager);



            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.False(canMove);
        }

        [Theory]
        [InlineData(8, 1)]
        [InlineData(8, 8)]
        public void Castling_ForNotValidMoves_ReturnTrue2(int x, int y)
        {
            bool canMove = true;
            var grid = new GridCreator();
            var board = grid.InitGrid();
            board[8, 2] = ' ';
            board[8, 3] = ' ';
            board[8, 5] = ' ';
            board[8, 6] = ' ';
            board[8, 7] = ' ';


            var pawn = new WhiteKing(8, 4);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var gridMan = new GridManager(_pawnManager);



            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.True(canMove);
        }


        [Theory]
        [InlineData(8, 1)]

        public void Castling_ForNotValidMoves_ReturnTrue3(int x, int y) 
        {
            bool canMove = true;
            var grid = new GridCreator();
            var board = grid.InitGrid();
            board[8, 2] = ' ';
            board[8, 3] = ' ';
            board[8, 8] = ' ';


            var pawn = new WhiteKing(8, 4);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var gridMan = new GridManager(_pawnManager);



            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.True(canMove);
        }
    }
}
