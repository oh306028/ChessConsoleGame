using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class CheckMateTests
    {


        [Fact]
        public void CheckMateBlack_ForNotValidChecks_ReturnFalse2() 
        {
                

            var gridCreator = new GridCreator();
            var board = gridCreator.InitGrid();

            board[8, 1] = 'K';
            board[8, 2] = ' ';
            board[7, 1] = ' ';
            board[8, 4] = 'p';

            board[4, 7] = 'q';
            var checkService = new CheckService();
            var move = new MoveManager(4, 1);
            var pawnTomove = new BlackQueen(4, 7);      
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();



            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);


            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {
                    

            }

            var result = checkMateChecker.IsCheckMateForBlack(board, x, y);



            Assert.False(result);
        }




        [Fact]
        public void CheckMateWhite_ForNotValidChecks_ReturnTru2()   
        {


            var gridCreator = new GridCreator();
            var board = gridCreator.InitGrid();

            board[1, 3] = 'r';
            board[1, 2] = ' ';
            board[1, 4] = ' ';
            board[1, 6] = ' ';
            board[1, 7] = ' ';
            board[1, 8] = 'r';
            board[2, 5] = ' ';
            board[2, 7] = ' ';
            board[3, 3] = 'N';
            board[5, 7] = 'Q';


            var checkService = new CheckService();
            var move = new MoveManager(1, 4);
            var pawnTomove = new WhiteQueen(4, 7);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();

      

            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);


            if (!checkService.CanWhitePiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMateForWhite(board, x, y);



            Assert.False(result);
        }



        [Fact]
        public void CheckMateWhite_ForNotValidChecks_ReturnFalse()  
        {
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(3, 1);
            var pawnTomove = new WhiteQueen(3, 2);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();

            board[3, 2] = 'Q';

            board[1, 1] = 'k';
            board[2, 1] = ' ';
            board[1, 2] = 'p';
            board[1, 3] = 'p';
            board[1, 5] = 'p';


            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);



            if (!checkService.CanWhitePiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMateForWhite(board, x, y);     



            Assert.False(result);
        }
         [Fact]
        public void CheckMateWhite_ForValidChecks_ReturnTrue()  
        {
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(6, 1);
            var pawnTomove = new WhiteQueen(6, 2);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();

            board[6, 2] = 'Q';

            board[1, 1] = 'k';
            board[2, 1] = ' ';
            board[1, 2] = 'p';
            board[1, 3] = 'p';
            board[1, 5] = 'p';


            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);



            if (!checkService.CanWhitePiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMateForWhite(board, x, y);



            Assert.True(result);
        }



        [Fact]
        public void CheckMateBlack_ForValidChecks_ReturnFalse2()    
        {
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(6, 1);
            var pawnTomove = new BlackQueen(6, 2);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();

            board[6, 2] = 'q';

            board[8, 1] = 'K';
            board[7, 1] = ' ';
            board[8, 2] = 'P';
            board[8, 3] = 'P';


            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);



            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMateForBlack(board, x, y);



            Assert.False(result);
        }

        [Fact]
        public void CheckMateBlack_ForValidChecks_ReturnTrue()  
        {
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(4, 1);
            var pawnTomove = new BlackQueen(4, 2);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();

            board[4, 2] = 'q';

            board[8, 1] = 'K';
            board[7, 1] = ' ';
            board[8, 2] = 'P';
            board[8, 3] = 'P';
            board[8, 4] = 'P';



            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);



            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMateForBlack(board, x, y);



            Assert.True(result);
        }
        [Fact]
        public void CheckMateBlack_FornotValidChecks_ReturnFalse()  
        {
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var checkService = new CheckService();
            var move = new MoveManager(4, 1);
            var pawnTomove = new BlackQueen(4, 2);
            var pawnManager = new PawnManager(pawnTomove, move);
            var gridManager = new GridManager(pawnManager);

            var checkMateChecker = new CheckMateChecker();

            board[4, 2] = 'q';

            board[8, 1] = 'K';
            board[7, 1] = ' ';
            board[8, 2] = 'P';
            board[8, 3] = 'P';
            board[7, 2] = 'R';


            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);



            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMateForBlack(board, x, y);



            Assert.False(result);


        }
    }
}
