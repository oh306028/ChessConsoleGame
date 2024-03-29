﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class QueenMovesOnGridTests
    {



        [Theory]
        [InlineData(2, 5)]
        [InlineData(1, 5)]
        [InlineData(1, 3)]
        [InlineData(2, 3)]

        public void QueenMoves_ForNotValidMoves_ReturnsFalse4(int x, int y)
        {
            bool canMove = true;
            var pawn = new BlackQueen(1, 4);
            var move = new MoveManager(x, y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);
            var gridMan = new GridManager(_pawnManager);
     


            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.False(canMove && _pawnManager.MovePawn());
        }


        [Theory]
        [InlineData(4, 1)]

        public void QueenMoves_ForNotValidMoves_ReturnsFalse3(int z, int v)
        {
            bool canMove = true;
            var pawn = new WhiteQueen(8, 5);
            var move = new MoveManager(z, v);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);
            var gridMan = new GridManager(_pawnManager);
            board[4, 1] = 'q';


            //act

            canMove = gridMan.CheckBoardBeforeChange(board);




            //assert
            Assert.False(canMove && _pawnManager.MovePawn());
        }


        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 5)]
        [InlineData(7, 5)]
        [InlineData(8, 6)]
        [InlineData(8, 4)]
        [InlineData(8, 3)]
        public void QueenMoves_ForNotValidMoves_ReturnsFalse(int z, int v)
        {
            bool canMove = true;
            var pawn = new WhiteQueen(8, 5);
            var move = new MoveManager(z, v);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);


            //act


            if (_pawnManager._pawn.symbol == 'B' || _pawnManager._pawn.symbol == 'b' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {



                if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition < _pawnManager.columnMove)
                {


                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x > _pawnManager.rowMove && y < _pawnManager.columnMove)
                    {
                        x--;
                        y++;
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
                        }


                    }

                }

            }
            if (_pawnManager._pawn.symbol == 'R' || _pawnManager._pawn.symbol == 'r' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {
                if (_pawnManager.rowMove != _pawnManager._pawn.rowPosition)
                {
                    if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition - 1; i >= _pawnManager.rowMove; i--)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }

                        }
                    }
                    else if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition + 1; i <= _pawnManager.rowMove; i++)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
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
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }


                        }
                    }
                    else
                    {
                        for (int i = _pawnManager._pawn.columnPosition + 1; i <= _pawnManager.columnMove; i++)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }


                        }
                    }

                }
            }






            //assert
            Assert.False(canMove && _pawnManager.MovePawn());
        }


        [Theory]
        [InlineData(8, 4)]

        public void QueenMoves_ForNotValidMoves_ReturnsFalse2(int z, int v)
        {
            bool canMove = true;
            var pawn = new BlackQueen(5, 7);
            var move = new MoveManager(z, v);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);

            board[8, 4] = ' ';


            //act


            if (_pawnManager._pawn.symbol == 'B' || _pawnManager._pawn.symbol == 'b' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {



                if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition < _pawnManager.columnMove)
                {


                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x > _pawnManager.rowMove && y < _pawnManager.columnMove)
                    {
                        x--;
                        y++;
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
                        }


                    }

                }

            }
            if (_pawnManager._pawn.symbol == 'R' || _pawnManager._pawn.symbol == 'r' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {
                if (_pawnManager.rowMove != _pawnManager._pawn.rowPosition)
                {
                    if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition - 1; i >= _pawnManager.rowMove; i--)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }

                        }
                    }
                    else if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition + 1; i <= _pawnManager.rowMove; i++)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
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
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }


                        }
                    }
                    else
                    {
                        for (int i = _pawnManager._pawn.columnPosition + 1; i <= _pawnManager.columnMove; i++)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }


                        }
                    }

                }
            }






            //assert
            Assert.False(canMove && _pawnManager.MovePawn());
        }



        [Theory]
        [InlineData(5, 5)]
        [InlineData(7, 5)]
        [InlineData(6, 5)]

        public void QueenMoves_ForValidMoves_ReturnsTrue(int z, int v)  
        {
            bool canMove = true;
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var pawn = new WhiteQueen(8, 5);
            var move = new MoveManager(z, v);
            var _pawnManager = new PawnManager(pawn, move);

            var attackService = new PieceAttacksService(pawn);

            board[7, 5] = ' ';
            board[5, 5] = 'p';

            //act

            if (_pawnManager._pawn.symbol == 'B' || _pawnManager._pawn.symbol == 'b' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {



                if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition < _pawnManager.columnMove)
                {


                    int x = _pawnManager._pawn.rowPosition;
                    int y = _pawnManager._pawn.columnPosition;
                    while (x > _pawnManager.rowMove && y < _pawnManager.columnMove)
                    {
                        x--;
                        y++;
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
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
                        if (board[x, y] != ' ' && board[x, y] != board[_pawnManager.rowMove, _pawnManager.columnMove])
                        {
                            canMove = false;
                            break;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
                        }


                    }

                }

            }
            if (_pawnManager._pawn.symbol == 'R' || _pawnManager._pawn.symbol == 'r' || _pawnManager._pawn.symbol == 'Q' || _pawnManager._pawn.symbol == 'q')
            {
                if (_pawnManager.rowMove != _pawnManager._pawn.rowPosition)
                {
                    if (_pawnManager._pawn.rowPosition > _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition - 1; i >= _pawnManager.rowMove; i--)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }

                        }
                    }
                    else if (_pawnManager._pawn.rowPosition < _pawnManager.rowMove && _pawnManager._pawn.columnPosition == _pawnManager.columnMove)
                    {
                        for (int i = _pawnManager._pawn.rowPosition + 1; i <= _pawnManager.rowMove; i++)
                        {
                            if (board[i, _pawnManager._pawn.columnPosition] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
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
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }


                        }
                    }
                    else
                    {
                        for (int i = _pawnManager._pawn.columnPosition + 1; i <= _pawnManager.columnMove; i++)
                        {
                            if (board[_pawnManager._pawn.rowPosition, i] != ' ' && i != _pawnManager.rowMove)
                            {

                                canMove = false;
                                break;

                            }

                            if (i == _pawnManager.rowMove && attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = true;
                            }

                            if (board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ' && !attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove))
                            {
                                canMove = false;
                            }


                        }
                    }

                }
            }






            //assert
            Assert.True(canMove && _pawnManager.MovePawn());
        }
    }
    
}
