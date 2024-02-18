using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{

    public class RockValisMovesOnGrid
    {

        [Theory]
        [InlineData(7, 8)]
        [InlineData(6, 8)]
        [InlineData(1, 8)]
        [InlineData(8, 7)]
        [InlineData(8, 1)]
        [InlineData(8, 5)]
        [InlineData(2, 8)]

        public void ValidRockMovesOnGrid_ForNotValidMoves_ReturnFalse(int x, int y) 
        {   
            //arrange
            bool canMove = true;
            var pawn = new WhiteRock(8,8);
            var move = new MoveManager(x,y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);


            //act

          

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
            Assert.False(canMove);

        }



         [Theory]
        [InlineData(2, 8)]
        [InlineData(3, 8)]
        [InlineData(4, 8)]
        [InlineData(5, 8)]
        [InlineData(6, 8)]
        [InlineData(7, 8)]

        public void ValidRockMovesOnGrid_ForValidMoves_ReturnTrue(int x, int y) 
        {       
            //arrange
            bool canMove = true;
            var pawn = new WhiteRock(8,8);
            var move = new MoveManager(x,y);
            var _pawnManager = new PawnManager(pawn, move);
            var grid = new GridCreator();
            var board = grid.InitGrid();
            var attackService = new PieceAttacksService(pawn);


            board[7, 8] = ' ';

            //act

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
            Assert.True(canMove);

        }



        [Fact]

        public void ValidRockAttackingMovesOnGrid_ForValidMoves_ReturnTrue()    
        {
            //arrange
            bool canMove = true;
           
       
            var grid = new GridCreator();
            var board = grid.InitGrid();
            board[6, 5] = 'R';
            board[6, 3] = 'q';

            var pawn = new WhiteRock(6, 5);
            var move = new MoveManager(6, 3);
            var _pawnManager = new PawnManager(pawn, move);
            var attackService = new PieceAttacksService(pawn);



            //act

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
            Assert.True(canMove);

        }


    }
}
