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
        public void CheckMate_ForValidChecks_ReturnFalse2() 
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

            var result = checkMateChecker.IsCheckMate(board, x, y);



            Assert.False(result);
        }

        [Fact]
        public void CheckMate_ForValidChecks_ReturnTrue()
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


            int x; int y;

            gridManager.ChangeBoardAfterChange(ref board);



            if (!checkService.CanBlackPiecesCheck(board, out x, out y))
            {


            }

            var result = checkMateChecker.IsCheckMate(board, x, y);



            Assert.True(result);
        }
        [Fact]
        public void CheckMate_FornotValidChecks_ReturnFalse()
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

            var result = checkMateChecker.IsCheckMate(board, x, y);



            Assert.False(result);


        }
    }
}
