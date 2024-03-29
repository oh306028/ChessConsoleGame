﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public  class CheckMateChecker
    {
        private  int kingXPosition;
        private  int kingYPosition;
        private List<Tuple<int, int>> Coordinates;

        private void CreateAListOfCordinatesToDiscardCheckForWhitePieces(int xPosChecker, int yPosCheker, char[,] board)    
        {
            Coordinates = new List<Tuple<int, int>>();
            var symbol = board[xPosChecker, yPosCheker];


            Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));


            if (symbol == 'q' || symbol == 'r')
            {
                if (kingXPosition > xPosChecker && kingYPosition == yPosCheker)
                {
                    for (int i = xPosChecker; i < kingXPosition; i++)
                    {
                        Coordinates.Add(Tuple.Create(i, yPosCheker));

                    }
                }

                if (kingXPosition < xPosChecker && kingYPosition == yPosCheker)
                {
                    for (int i = xPosChecker; i > kingXPosition; i--)
                    {
                        Coordinates.Add(Tuple.Create(i, yPosCheker));

                    }
                }

                if (kingXPosition == xPosChecker && kingYPosition > yPosCheker)
                {
                    for (int i = yPosCheker; i < kingXPosition; i++)
                    {
                        Coordinates.Add(Tuple.Create(kingXPosition, i));

                    }
                }

                if (kingXPosition == xPosChecker && kingYPosition < yPosCheker)
                {
                    for (int i = yPosCheker; i > kingXPosition; i--)
                    {
                        Coordinates.Add(Tuple.Create(kingXPosition, i));

                    }
                }

            }

            
            if (symbol == 'b' || symbol == 'q' )
            {

                if (kingXPosition > xPosChecker && kingYPosition > yPosCheker)
                {
                    while (kingXPosition > xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker--;
                        yPosCheker--;

                    }

                }

                if (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker++;
                        yPosCheker--;

                    }
                }

                if (kingXPosition > xPosChecker && kingYPosition < yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker--;
                        yPosCheker++;

                    }
                }


                if (kingXPosition < xPosChecker && kingYPosition < yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker++;
                        yPosCheker++;

                    }
                }
            }
            
        }   
        private void CreateAListOfCordinatesToDiscardCheckForBlackPieces(int xPosChecker, int yPosCheker, char[,] board)      
        {
            Coordinates = new List<Tuple<int, int>>();
            var symbol = board[xPosChecker, yPosCheker];


            Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));


            if (symbol == 'Q' || symbol == 'R')
            {
                if (kingXPosition > xPosChecker && kingYPosition == yPosCheker)
                {
                    for (int i = xPosChecker; i < kingXPosition; i++)
                    {
                        Coordinates.Add(Tuple.Create(i, yPosCheker));

                    }
                }

                if (kingXPosition < xPosChecker && kingYPosition == yPosCheker)
                {
                    for (int i = xPosChecker; i > kingXPosition; i--)
                    {
                        Coordinates.Add(Tuple.Create(i, yPosCheker));

                    }
                }

                if (kingXPosition == xPosChecker && kingYPosition > yPosCheker)
                {
                    for (int i = yPosCheker; i < kingXPosition; i++)
                    {
                        Coordinates.Add(Tuple.Create(kingXPosition, i));

                    }
                }

                if (kingXPosition == xPosChecker && kingYPosition < yPosCheker)
                {
                    for (int i = yPosCheker; i > kingYPosition; i--)
                    {
                        Coordinates.Add(Tuple.Create(kingXPosition, i));

                    }
                }

            }


            if (symbol == 'B' || symbol == 'Q')
            {

                if (kingXPosition > xPosChecker && kingYPosition > yPosCheker)
                {
                    while (kingXPosition > xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker--;
                        yPosCheker--;

                    }

                }

                if (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker++;
                        yPosCheker--;

                    }
                }

                if (kingXPosition > xPosChecker && kingYPosition < yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker--;
                        yPosCheker++;

                    }
                }


                if (kingXPosition < xPosChecker && kingYPosition < yPosCheker)
                {
                    while (kingXPosition < xPosChecker && kingYPosition > yPosCheker)
                    {
                        Coordinates.Add(Tuple.Create(xPosChecker, yPosCheker));
                        xPosChecker++;
                        yPosCheker++;

                    }
                }
            }

        }

        private bool CanMoveTioDiscardCheck(char[,] board, IPawn pawn, int xPosChecker, int yPosChecker) 
        {          

            int listcount = Coordinates.Count() - 1;
            while (listcount >= 0)
            {
                var pawnManager = new PawnManager(pawn, new MoveManager(Coordinates[listcount].Item1, Coordinates[listcount].Item2));
                var grid = new GridManager(pawnManager);

                if (grid.CheckBoardBeforeChange(board))
                {
                    return true;
                }
                listcount--;
            }

            return false;

        }

        private bool CanWhiteKingEscapeCheckMate(char[,]board)
        {
            var king = new WhiteKing(kingXPosition, kingYPosition);

            var kingMoves = new List<Tuple<int, int>>() { Tuple.Create(kingXPosition-1, kingYPosition-1), Tuple.Create(kingXPosition + 1, kingYPosition + 1),
                Tuple.Create(kingXPosition - 1, kingYPosition),  Tuple.Create(kingXPosition + 1, kingYPosition),  Tuple.Create(kingXPosition - 1, kingYPosition)
            , Tuple.Create(kingXPosition - 1, kingYPosition + 1),  Tuple.Create(kingXPosition + 1, kingYPosition - 1),  Tuple.Create(kingXPosition , kingYPosition - 1),
             Tuple.Create(kingXPosition, kingYPosition + 1)};


            foreach(var kingMove in kingMoves)
            {
                var move = new MoveManager(kingMove.Item1, kingMove.Item2);
                if (!move.ValidCordinates())
                    continue;

                var pawnManager = new PawnManager(king,move );
                var grid = new GridManager(pawnManager);
                

                if (grid.CheckBoardBeforeChange(board) && !Coordinates.Contains(kingMove))
                {
                    return true;
                }

            }

            return false;
        }
        private bool CanBlackKingEscapeCheckMate(char[,] board) 
        {
            var king = new BlackKing(kingXPosition, kingYPosition);
                
            var kingMoves = new List<Tuple<int, int>>() { Tuple.Create(kingXPosition-1, kingYPosition-1), Tuple.Create(kingXPosition + 1, kingYPosition + 1),
                Tuple.Create(kingXPosition - 1, kingYPosition),  Tuple.Create(kingXPosition + 1, kingYPosition),  Tuple.Create(kingXPosition - 1, kingYPosition)
            , Tuple.Create(kingXPosition - 1, kingYPosition + 1),  Tuple.Create(kingXPosition + 1, kingYPosition - 1),  Tuple.Create(kingXPosition , kingYPosition - 1),
             Tuple.Create(kingXPosition, kingYPosition + 1)};


            foreach (var kingMove in kingMoves)
            {
                var move = new MoveManager(kingMove.Item1, kingMove.Item2);
                if (!move.ValidCordinates())
                    continue;

                var pawnManager = new PawnManager(king, move);
                var grid = new GridManager(pawnManager);


                if (grid.CheckBoardBeforeChange(board) && !Coordinates.Contains(kingMove))
                {
                    return true;
                }

            }

            return false;
        }


        public bool IsCheckMateForBlack(char[,] board, int xPosChecker, int yPosCheker)     
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

            CreateAListOfCordinatesToDiscardCheckForWhitePieces(xPosChecker, yPosCheker, board);

            
            if (CanWhiteKingEscapeCheckMate(board))
                return false;
            

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

        public bool IsCheckMateForWhite(char[,] board, int xPosChecker, int yPosCheker) 
        {

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (board[i, j] == 'k')
                    {
                        kingXPosition = i; kingYPosition = j;
                        break;
                    }
                }
            }

            
            CreateAListOfCordinatesToDiscardCheckForBlackPieces(xPosChecker, yPosCheker, board);

            
            if (CanBlackKingEscapeCheckMate(board)) 
                return false;
            

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {

                    if (board[i, j] == 'r')
                    {
                        var pawn = new BlackRock(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;

                    }



                    if (board[i, j] == 'b')
                    {
                        var pawn = new BlackBishop(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;
                    }


                    if (board[i, j] == 'q')
                    {

                        var pawn = new BlackQueen(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                        {
                            return false;
                        }

                    }


                    if (board[i, j] == 'n')
                    {
                        var pawn = new BlackKnight(i, j);

                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;
                    }


                    if (board[i, j] == 'p')
                    {
                        var pawn = new BlackPawn(i, j);
                      
                        if (CanMoveTioDiscardCheck(board, pawn, xPosChecker, yPosCheker))
                            return false;
                    }

                }

            }



            return true;
        }
    }
}
