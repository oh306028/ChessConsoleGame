using ChessGame;
using System;

class Program
{
    static void Main(string[] args)
    {


        var gridCreator = new GridCreator();

        var chessBoard = gridCreator.InitGrid();
        gridCreator.ShowBoard();


        var pawn = new BlackPawn(2, 2);
        var move = new MoveManager(2, 3);

        Console.WriteLine();
        Console.WriteLine();

        var pawnManager = new PawnManager(pawn, gridCreator, move);
        pawnManager.Move();



        gridCreator.ShowBoard();




    }
}
