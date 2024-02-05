﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChessGame
{
    public class GridManager
    {
        private Grid _grid = new Grid();

        private PawnManager _pawnManager;



        public GridManager(PawnManager pawnManager) 
        {
            _pawnManager = pawnManager;
            


        }

        private bool CanCastle(char[,] board, out char rock)
        {

            rock = 'R';
            if (_pawnManager._pawn.symbol == 'K' && board[_pawnManager.rowMove, _pawnManager.columnMove] == 'R')
            {
                
                if(_pawnManager.columnMove > _pawnManager._pawn.columnPosition)
                {
                    for (int i = _pawnManager._pawn.columnPosition+1; i < _pawnManager.columnMove; i++)
                    {
                        if (board[_pawnManager.rowMove, i] != ' ')
                            return false;
                    }
                }

                if (_pawnManager.columnMove < _pawnManager._pawn.columnPosition)
                {
                    for (int i = _pawnManager._pawn.columnPosition-1; i > _pawnManager.columnMove; i--)
                    {
                        if (board[_pawnManager.rowMove, i] != ' ')
                            return false;
                    }
                }

            }

            
            if (_pawnManager._pawn.symbol == 'k' && board[_pawnManager.rowMove, _pawnManager.columnMove] == 'r')
            {
                rock = 'r';
                if (_pawnManager.columnMove > _pawnManager._pawn.columnPosition)
                {
                    for (int i = _pawnManager._pawn.columnPosition+1; i < _pawnManager.columnMove; i++)
                    {
                        if (board[_pawnManager.rowMove, i] != ' ')
                            return false;
                    }
                }

                if (_pawnManager.columnMove < _pawnManager._pawn.columnPosition)
                {
                    for (int i = _pawnManager._pawn.columnPosition-1; i > _pawnManager.columnMove; i--)
                    {
                        if (board[_pawnManager.rowMove, i] != ' ')
                            return false;
                    }
                }

            }

            return true;
        }


        public void ShowBoard(char[,] board)
        {
            
            for (int i = 0; i < _grid.collumns; i++)
            {
                for (int j = 0; j < _grid.rows; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }
        }


        public void ChangeBoardAfterChange(ref char[,] board)
        {
            var attackService = new PieceAttacksService(_pawnManager._pawn);
            bool canMove = true;

           
            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' '
                && (_pawnManager._pawn.symbol == 'P' || _pawnManager._pawn.symbol == 'p') && !_pawnManager._pawn.CanAttack(_pawnManager.rowMove, _pawnManager.columnMove))
            {
                Console.WriteLine("Cannot move here");
                return;
            }else if(board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                canMove = false;
            
          
                

            if (_pawnManager._pawn.rowPosition == _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
            {
                canMove = false;
            }



            if (_pawnManager._pawn.symbol == 'R' || _pawnManager._pawn.symbol == 'r' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {
                if (_pawnManager.rowMove != _pawnManager._pawn.rowPosition)
                {
                    if(_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition - 1; i >= _pawnManager.rowMove; i--)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ')
                            {
                                canMove = false;
                            }

                        }
                    }
                    else if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition + 1; i <= _pawnManager.rowMove; i++)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ')
                            {
                                canMove = false;
                            }

                        }
                    }
                   
                }



                if (_pawnManager.columnMove != _pawnManager._pawn.columnPosition && _pawnManager._pawn.rowPosition == _pawnManager.rowMove)
                {
                    if (_pawnManager._pawn.columnPosition > _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.columnPosition - 1; i >= _pawnManager.columnMove; i--)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ')
                            {
                                canMove = false;
                            }

                        }
                    }
                    else
                    {
                        for (int i = _pawnManager._pawn.columnPosition + 1; i <= _pawnManager.columnMove; i++)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ')
                            {
                                canMove = false;
                            }

                        }
                    }
                      
                }
            }
            
            if(_pawnManager._pawn.symbol == 'B' || _pawnManager._pawn.symbol == 'b' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {

               

                if(_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition < _pawnManager.columnMove)
                {
                   
                        
                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x > _pawnManager.rowMove && y < _pawnManager.columnMove)
                    {
                        x--;
                        y++;
                        if (board[x,y] != ' ')
                        {
                            canMove = false;
                        }
                        
                    }
            
                }
                
                if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition > _pawnManager.columnMove)
                {
                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x < _pawnManager.rowMove && y > _pawnManager.columnMove)
                    {
                        x++;
                        y--;
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
                        }
                            
                        
                    }
                
                }

                if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition > _pawnManager.columnMove)
                {
                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x > _pawnManager.rowMove && y > _pawnManager.columnMove)
                    {
                        x--;
                        y--;
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
                        }
                        


                    }

                }



                if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition < _pawnManager.columnMove)
                {
                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x < _pawnManager.rowMove && y < _pawnManager.columnMove)
                    {
                        x++;
                        y++;
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
                        }


                    }

                }
 
            }


            if (!canMove)
            {
                if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                {
                    canMove = true;
                }
            }

            char rock = '0';
            if (_pawnManager._pawn.symbol == 'k' || _pawnManager._pawn.symbol == 'K')
            {
                if (CanCastle(board, out rock))
                {
                    if (_pawnManager.columnMove > _pawnManager._pawn.columnPosition)
                    {
                        if (rock == 'R')
                        {
                            board[_pawnManager._pawn.rowPosition, _pawnManager._pawn.columnPosition] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove - 1] = 'K';
                            board[_pawnManager.rowMove, _pawnManager.columnMove - 2] = 'R';
                            
                            return;
                        }

                        if (rock == 'r')
                        {
                            board[_pawnManager._pawn.rowPosition, _pawnManager._pawn.columnPosition] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove - 1] = 'k';
                            board[_pawnManager.rowMove, _pawnManager.columnMove - 2] = 'r';
                            return;
                        }
                    }

                    if (_pawnManager.columnMove < _pawnManager._pawn.columnPosition)
                    {
                        if (rock == 'R')
                        {
                            board[_pawnManager._pawn.rowPosition, _pawnManager._pawn.columnPosition] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove + 1] = 'K';
                            board[_pawnManager.rowMove, _pawnManager.columnMove + 2] = 'R';
                            return;
                        }

                        if (rock == 'r')
                        {
                            board[_pawnManager._pawn.rowPosition, _pawnManager._pawn.columnPosition] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove] = ' ';
                            board[_pawnManager.rowMove, _pawnManager.columnMove + 1] = 'k';
                            board[_pawnManager.rowMove, _pawnManager.columnMove + 2] = 'r';
                            return;
                        }
                    }



                }
            }
          


            if (_pawnManager.MovePawn() && canMove)
            {

                board[_pawnManager.rowMove, _pawnManager.columnMove] = _pawnManager._pawn.symbol;
                board[_pawnManager._pawn.rowPosition, _pawnManager._pawn.columnPosition] = ' ';
            }
            else
            {
                Console.WriteLine("Cannot move here");
                return;
            }
        }

    }
}
