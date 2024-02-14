using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class BishopMovesOnGridTests
    {
        [Theory]
        [InlineData(6, 4)]
        [InlineData(6, 1)]
        [InlineData(8, 2)]
        [InlineData(8, 4)]
        [InlineData(7, 2)]
        [InlineData(7, 3)]
        [InlineData(7, 4)]
        public void BishopMoves_ForNotValidMoves_ReturnFalse(int z, int v)
        {
            bool canMove = true;
            var pawn = new WhiteBishop(8, 3);
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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
                        }


                    }

                }

            }





            //assert
            Assert.False(canMove && _pawnManager.MovePawn());
        }


        [Theory]
        [InlineData(7, 2)]
        [InlineData(6, 1)]

        public void BishopMoves_ForValidMoves_ReturnTrue(int z, int v)  
        {
            bool canMove = true;
            var pawn = new WhiteBishop(8, 3);
            var move = new MoveManager(z, v);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);

            board[7, 2] = ' ';
            board[6, 1] = 'p';

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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
                            if(attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                            {
                                canMove = true;
                            }
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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
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
                        if (board[x, y] != ' ')
                        {
                            canMove = false;
                        }
                        if (attackService.IsAttacking(board, _pawnManager.rowMove, _pawnManager.columnMove) && board[_pawnManager.rowMove, _pawnManager.columnMove] != ' ')
                        {
                            canMove = true;
                        }


                    }

                }

            }





            //assert
            Assert.True(canMove && _pawnManager.MovePawn());
        }
    }


}
