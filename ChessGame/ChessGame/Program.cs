using ChessGame;
using System;
using System.Threading.Channels;

class Program
{

    public static void show(char[,] board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {

        bool game = true;

        var gridCreator = new GridCreator();
        var chessBoard = gridCreator.InitGrid();

        show(chessBoard);

        while (game)
        {

            Console.WriteLine("Please choose your figure: ");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            var pawn = new BlackPawn(x, y);

            Console.WriteLine("Please choose where your figure should move: ");
            int xMove = int.Parse(Console.ReadLine());
            int yMove = int.Parse(Console.ReadLine());


            var move = new MoveManager(xMove, yMove);
            if (!move.ValidCordinates())
                return;


            var pawnManager = new PawnManager(pawn, move);
            var gridManager = new GridManager(pawnManager);


            gridManager.ChangeBoardAfterChange(ref chessBoard);

            Console.WriteLine();
            Console.WriteLine();

            gridManager.ShowBoard(chessBoard);


        }

    



      







    }
}
