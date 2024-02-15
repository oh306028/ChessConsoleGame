using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class CheckService
    {

        private int kingXPosition;
        private int kingYPosition;
     

        private bool CanCheck(char[,] board, MoveManager _move, IPawn pawn)
        {
                var pawnManager = new PawnManager(pawn, _move);
                var grid = new GridManager(pawnManager);

                if (grid.CheckBoardBeforeChange(board))
                    return true;


            return false;
        }


        public bool CheckingChecks(char[,] board)
        {
            MoveManager _move = new MoveManager(0,0);

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (board[i, j] == 'K')
                    {
                        kingXPosition = i; kingYPosition = j;
                        _move = new MoveManager(kingXPosition, kingYPosition);
                        board[kingXPosition, kingYPosition] = 'P';
                        break;
                    }
                }
            }


                    for (int i = 1; i < 9; i++)
                    {
                for (int j = 1; j < 9; j++)
                {
                    
                    if (board[i, j] == 'r')
                    {
                        var pawn = new BlackRock(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;

                    }

                    if (board[i, j] == 'b')
                    {
                        var pawn = new BlackBishop(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;
                    }


                    if (board[i, j] == 'q')
                    {
                        board[kingXPosition, kingYPosition] = ' ';
                        var pawn = new BlackQueen(i, j);              

                        if (CanCheck(board, _move, pawn))
                        { 
                            board[kingXPosition, kingYPosition] = 'K';
                            return true;
                        }
                            
                    }


                    if (board[i, j] == 'n')
                    {
                        var pawn = new BlackKnight(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;
                    }


                    if (board[i, j] == 'p')
                    {
                        var pawn = new BlackPawn(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;
                    }

                }

            }
            board[kingXPosition, kingYPosition] = 'K';
            return false;
            
        }

    }

   
}
