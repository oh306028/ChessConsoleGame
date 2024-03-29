﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Test
{
    public class PawnManagerTests
    {
        [Fact]

        public void MoveBlackPawn_ForValidMove_ReturnsTrue()
        {
            //arrange
            var pawn = new BlackPawn(2,2);
            var move = new MoveManager(3,2);
            var pawnManager = new PawnManager(pawn,move);

            //act
            var result = pawnManager._pawn.CanMove(move.rowDirection, move.columnDirection);

            //assert
            Assert.True(result);

        }

        [Fact]
        public void MoveBlackPawn_ForValidMove_ReturnsTrue2()
        {
            //arrange
            var pawn = new BlackPawn(2, 2);
            var move = new MoveManager(4, 2);
            var pawnManager = new PawnManager(pawn, move);

            //act
            var result = pawnManager._pawn.CanMove(move.rowDirection, move.columnDirection);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void MoveWhitePawn_ForValidMove_ReturnsTrue()
        {
            //arrange
            var pawn = new WhitePawn(7, 2);
            var move = new MoveManager(6, 2);
            var pawnManager = new PawnManager(pawn, move);

            //act
            var result = pawnManager._pawn.CanMove(move.rowDirection, move.columnDirection);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void MoveWhitePawn_ForValidMove_ReturnsTrue2()
        {
            //arrange
            var pawn = new WhitePawn(7, 2);
            var move = new MoveManager(5, 2);
            var pawnManager = new PawnManager(pawn, move);

            //act
            var result = pawnManager._pawn.CanMove(move.rowDirection, move.columnDirection);

            //assert
            Assert.True(result);
        }
    }
}
