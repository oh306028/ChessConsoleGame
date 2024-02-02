using ChessGame;
using System;

class Program
{
    static void Main(string[] args)
    {



        var gridCreator = new GridCreator();
        var chessBoard = gridCreator.InitGrid();

        var pawn = new BlackPawn(2, 7);
        var move = new MoveManager(4, 7);



        var pawnManager = new PawnManager(pawn, move);
        var gridManager = new GridManager(pawnManager);

        gridManager.ShowBoard(chessBoard);





        gridManager.ChangeBoardAfterChange(ref chessBoard);

        Console.WriteLine();
        Console.WriteLine();

        gridManager.ShowBoard(chessBoard);







    }
}
