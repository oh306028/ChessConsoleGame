using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class CheckServiceTests
    {

        [Fact]


        public void CheckService_CheckAfterSomePieceMove_FromAnotherPiece_ReturnsTrue() 
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(6, 5);
            var pawnTomove = new WhitePawn(7, 5);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);


         
            board[6, 6] = 'q';



            if (!checkService.CheckingChecks(board))
            {
                gridManager.ChangeBoardAfterChange(ref board);
            }

            var result = checkService.CheckingChecks(board);



            Assert.True(result);
        }

        [Theory]
        [InlineData(6, 5)]
        [InlineData(6, 3)]
        

        public void CheckService_ForKnightValidChecks_ReturnsTrue(int x, int y) 
        {
         
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();

          //  board[7, 4] = ' ';
            board[x, y] = 'n';


            var result = checkService.CheckingChecks(board);




            Assert.True(result);
        }

        [Theory]
        [InlineData(6, 2)]
        [InlineData(5, 4)]
        public void CheckService_ForNotKnightValidChecks_ReturnsFalse(int x, int y) 
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();

            //  board[7, 4] = ' ';
            board[x, y] = 'n';


            var result = checkService.CheckingChecks(board);




            Assert.False(result);
        }




        [Theory]
        [InlineData(6, 4)]
        [InlineData(4, 4)]
        [InlineData(6, 6)]
        [InlineData(5, 7)]


        public void CheckService_ForQueenValidChecks_ReturnsTrue(int x, int y)  
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();

            board[7, 4] = ' ';
            board[7, 5] = ' ';
            board[x, y] = 'q';


            var result = checkService.CheckingChecks(board);




            Assert.True(result);
        }



        [Theory]
        [InlineData(6, 4)]
        [InlineData(4, 4)]
        [InlineData(6, 6)]
        [InlineData(5, 7)]


        public void CheckService_ForQueenNotValidChecks_ReturnsFalse(int x, int y)  
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();

         
            board[x, y] = 'q';


            var result = checkService.CheckingChecks(board);




            Assert.False(result);
        }
    }
}
