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

            IPawn figure = null;
            char answer = chessBoard[x, y];


           

            switch (answer)
            {
                case 'P':
                    figure = new WhitePawn(x, y);
                    break;
                case 'R':
                    figure = new WhiteRock(x, y);
                    break;
                case 'p':
                    figure = new BlackPawn(x, y);
                    break;
                case 'r':
                    figure = new BlackRock(x, y);
                    break;
                case 'N':
                    figure = new WhiteKnight(x, y);
                    break;
                default:
                    Console.WriteLine("Bad choice");
                    break;
            }




            Console.WriteLine("Please choose where your figure should move: ");
            int xMove = int.Parse(Console.ReadLine());
            int yMove = int.Parse(Console.ReadLine());


            var move = new MoveManager(xMove, yMove);
            if (!move.ValidCordinates())
                return;


            var pawnManager = new PawnManager(figure, move);
            var gridManager = new GridManager(pawnManager);


            gridManager.ChangeBoardAfterChange(ref chessBoard);

            Console.WriteLine();
            Console.WriteLine();

            gridManager.ShowBoard(chessBoard);


        }

    



      







    }
}
