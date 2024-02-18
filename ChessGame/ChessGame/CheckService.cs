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


        public bool CheckingChecks(char[,] board, out int x, out int y)
        {
            MoveManager _move = new MoveManager(0,0);

            //FOR BLACK PIECES

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
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                            return true;

                    }

                    if (board[i, j] == 'b')
                    {
                        var pawn = new BlackBishop(i, j);
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                            return true;
                    }


                    if (board[i, j] == 'q')
                    {
                        board[kingXPosition, kingYPosition] = ' ';
                        var pawn = new BlackQueen(i, j);
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                        { 
                            board[kingXPosition, kingYPosition] = 'K';
                            return true;
                        }
                            
                    }


                    if (board[i, j] == 'n')
                    {
                        var pawn = new BlackKnight(i, j);
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                            return true;
                    }


                    if (board[i, j] == 'p')
                    {
                        x = i; y = j;
                        var pawn = new BlackPawn(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;
                    }

                }

            }

            board[kingXPosition, kingYPosition] = 'K';


            //FOR WHITE PIECES


            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (board[i, j] == 'k')
                    {
                        kingXPosition = i; kingYPosition = j;
                        _move = new MoveManager(kingXPosition, kingYPosition);
                        board[kingXPosition, kingYPosition] = 'p';
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
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                            return true;

                    }

                    if (board[i, j] == 'B')
                    {
                        var pawn = new WhiteBishop(i, j);
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                            return true;
                    }


                    if (board[i, j] == 'Q')
                    {
                        board[kingXPosition, kingYPosition] = ' ';
                        var pawn = new WhiteQueen(i, j);
                        x = i; y = j;
                        if (CanCheck(board, _move, pawn))
                        {
                            board[kingXPosition, kingYPosition] = 'K';
                            return true;
                        }

                    }


                    if (board[i, j] == 'N')
                    {
                        x = i; y = j;
                        var pawn = new WhiteKnight(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;
                    }


                    if (board[i, j] == 'P')
                    {
                        x = i; y = j;
                        var pawn = new WhitePawn(i, j);

                        if (CanCheck(board, _move, pawn))
                            return true;
                    }

                }

            }



            board[kingXPosition, kingYPosition] = 'k';
            x = 0; y = 0;
            return false;
            
        }

    }

   
}
