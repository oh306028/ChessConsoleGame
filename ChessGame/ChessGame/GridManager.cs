using System;
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

            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !_pawnManager._pawn.CanAttack(_pawnManager.rowMove, _pawnManager.columnMove))
            {
                Console.WriteLine("Cannot move here");
                return;
            }

            
            if(_pawnManager._pawn.symbol == 'R' || _pawnManager._pawn.symbol == 'r')
            {
                if (_pawnManager.rowMove != _pawnManager._pawn.rowPosition)
                {
                    if(_pawnManager._pawn.rowPosition > _pawnManager.rowMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition - 1; i >= _pawnManager.rowMove; i--)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ')
                            {
                                Console.WriteLine("Cannot move here");
                                return;
                            }

                        }
                    }
                    else
                    {
                        for (int i = _pawnManager._pawn.rowPosition + 1; i <= _pawnManager.rowMove; i++)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ')
                            {
                                Console.WriteLine("Cannot move here");
                                return;
                            }

                        }
                    }
                   
                }



                if (_pawnManager.columnMove != _pawnManager._pawn.columnPosition)
                {
                    if (_pawnManager._pawn.columnPosition > _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.columnPosition - 1; i >= _pawnManager.columnMove; i--)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ')
                            {
                                Console.WriteLine("Cannot move here");
                                return;
                            }

                        }
                    }
                    else
                    {
                        for (int i = _pawnManager._pawn.columnPosition + 1; i <= _pawnManager.columnMove; i++)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ')
                            {
                                Console.WriteLine("Cannot move here");
                                return;
                            }

                        }
                    }
                      
                }
            }
            
            if(_pawnManager._pawn.symbol == 'B' || _pawnManager._pawn.symbol == 'b')
            {

                if (_pawnManager._pawn.rowPosition == _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                {
                    Console.WriteLine("Cannot move here");
                    return;
                }
                    

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
                            Console.WriteLine("Cannot move here");
                            return;
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
                            Console.WriteLine("Cannot move here");
                            return;
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
                            Console.WriteLine("Cannot move here");
                            return;
                        }


                    }

                }

                if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition < _pawnManager.columnMove)
                {
                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x < _pawnManager.rowMove && y < _pawnManager.columnMove)
                    {
                        x--;
                        y--;
                        if (board[x, y] != ' ')
                        {
                            Console.WriteLine("Cannot move here");
                            return;
                        }


                    }

                }



            }


            if (_pawnManager.MovePawn())
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
