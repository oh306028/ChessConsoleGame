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


        public void CheckService_WHITECheckAfterSomePieceMove_FromAnotherPiece_ReturnsTrue()    
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(6, 1);
            var pawnTomove = new WhitePawn(7, 1);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);



            board[6, 6] = 'q';
            board[7, 5] = ' ';


            int x; int y;

            var boardCopy = (char[,])board.Clone();
            gridManager.ChangeBoardAfterChange(ref boardCopy);
            if (!checkService.CanBlackPiecesCheck(boardCopy, out x, out y))
            {
                gridManager.ChangeBoardAfterChange(ref board);
            }

            var result = checkService.CanBlackPiecesCheck(board, out x, out y);





            Assert.True(result);
        }




        [Fact]


        public void CheckService_WHITECheckAfterSomePieceMove_FromAnotherPiece_ReturnsFalse()   
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(6, 6);
            var pawnTomove = new WhitePawn(7, 7);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);



            board[6, 6] = 'q';
            board[7, 5] = ' ';

            int x; int y;
            var boardCopy = (char[,])board.Clone();
            gridManager.ChangeBoardAfterChange(ref boardCopy);
            if (!checkService.CanBlackPiecesCheck(boardCopy, out x, out y))
            {
                gridManager.ChangeBoardAfterChange(ref board);
            }

            var result = checkService.CanBlackPiecesCheck(board, out x, out y);





            Assert.False(result);
        }





        [Fact]


        public void CheckService_CheckAfterSomePieceMove_FromAnotherPiece_ReturnsTrue2()    
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(6, 5);
            var pawnTomove = new WhitePawn(7, 5);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);



            board[6, 6] = 'q';

            var boardCopy = (char[,])board.Clone();
            int x; int y;

            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {
                gridManager.ChangeBoardAfterChange(ref boardCopy);
            }

            var result = checkService.CanBlackPiecesCheck(boardCopy, out x, out y);

            if (result)
            {
                gridManager.ChangeBoardAfterChange(ref board);
            }



            Assert.True(result);
        }




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

            int x; int y;

            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {
                gridManager.ChangeBoardAfterChange(ref board);
            }

            var result = checkService.CanBlackPiecesCheck(board, out x, out y);



            Assert.True(result);
        }

        [Fact]

        public void CheckService_WHITEPIECESCheckAfterSomePieceMove_FromAnotherPiece_ReturnsTrue()  
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(3, 6);
            var pawnTomove = new BlackPawn(2, 6);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);



            board[3, 7] = 'Q';

            int x; int y;

            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {
                gridManager.ChangeBoardAfterChange(ref board);
            }

            var result = checkService.CanBlackPiecesCheck(board, out x, out y);



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

            int x1; int y1;
            var result = checkService.CanBlackPiecesCheck(board, out x1, out y1);




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

            int x1; int y1;
            var result = checkService.CanBlackPiecesCheck(board, out x1, out y1);




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

            int x1; int y1;
            var result = checkService.CanBlackPiecesCheck(board, out x1, out y1);




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
            int x1; int y1;

            var result = checkService.CanBlackPiecesCheck(board, out x1, out y1);




            Assert.False(result);
        }



        [Theory]
        [InlineData(5, 1)]
        [InlineData(3, 3)]
        [InlineData(3, 5)]
        [InlineData(3, 7)]


        public void CheckService_ForWHITEPIECESQueenNotValidChecks_ReturnsFalse(int x, int y)   
        {

            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();


            board[x, y] = 'Q';

            int x1; int y1; 
            var result = checkService.CanBlackPiecesCheck(board, out x1, out y1);




            Assert.False(result);
        }

    }
}
