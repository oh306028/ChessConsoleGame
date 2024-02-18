using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public static class CheckMateChecker
    {
        private static int kingXPosition;
        private static int kingYPosition;
        private static bool CanMoveTioDiscardCheck(char[,] board, IPawn pawn, int xPosChecker, int yPosCheker)
        {

            var pairList = new List<Tuple<int, int>>();

            var symbol = board[xPosChecker, yPosCheker];

            if(symbol == 'P')
            {

            }

            if (symbol == 'q' || symbol == 'r')
            {
                if (kingXPosition > xPosChecker && kingYPosition == yPosCheker)
                {
                    for (int i = xPosChecker; i < kingXPosition; i++)
                    {
                        pairList.Add(Tuple.Create(i, yPosCheker));

                    }
                }

                if (kingXPosition < xPosChecker && kingYPosition == yPosCheker)
                {
                    for (int i = xPosChecker; i < kingXPosition; i--)
                    {
                        pairList.Add(Tuple.Create(i, yPosCheker));

                    }
                }

                if (kingXPosition == xPosChecker && kingYPosition > yPosCheker)
                {
                    for (int i = yPosCheker; i < kingXPosition; i++)
                    {
                        pairList.Add(Tuple.Create(kingXPosition, i));

                    }
                }

                if (kingXPosition == xPosChecker && kingYPosition < yPosCheker)
                {
                    for (int i = yPosCheker; i < kingXPosition; i--)
                    {
                        pairList.Add(Tuple.Create(kingXPosition, i));

                    }
                }

            }


            if (symbol == 'b' || symbol == 'q')
            {

                if (kingXPosition > xPosChecker && kingYPosition > yPosCheker)
                {
                    while (kingXPosition > xPosChecker && kingYPosition > yPosCheker)
                    {
                        pairList.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker--;
                        yPosCheker--;

                    }

                }

                if (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        pairList.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker++;
                        yPosCheker--;

                    }
                }

                if (kingXPosition > xPosChecker && kingYPosition < yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        pairList.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker--;
                        yPosCheker++;

                    }
                }


                if (kingXPosition < xPosChecker && kingYPosition < yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        pairList.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker++;
                        yPosCheker++;

                    }
                }
            }


            int listcount = pairList.Count() - 1;
            while (listcount >= 0)
            {
                var pawnManager = new PawnManager(pawn, new MoveManager(pairList[listcount].Item1, pairList[listcount].Item2));
                var grid = new GridManager(pawnManager);

                if (grid.CheckBoardBeforeChange(board))
                {
                    return true;
                }
                listcount--;
            }

            return false;

        }

            public static bool IsCheckMate(char[,] board, int xPosChecker, int yPosCheker)  
            {

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (board[i, j] == 'K')
                    {
                        kingXPosition = i; kingYPosition = j;                     
                        break;
                    }
                }
            }



            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {

                    if (board[i, j] == 'R')
                    {
                        var pawn = new WhiteRock(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;

                    }


                    
                    if (board[i, j] == 'B')
                    {
                        var pawn = new WhiteBishop(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;
                    }


                    if (board[i, j] == 'Q')
                    {
                       
                        var pawn = new WhiteQueen(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                        {                         
                            return false;
                        }

                    }


                    if (board[i, j] == 'N')
                    {
                        var pawn = new WhiteKnight(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;
                    }


                    if (board[i, j] == 'P')
                    {
                        var pawn = new WhitePawn(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;
                    }
                    
                }

            }



            return true;
        }
    }
}
