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
        var checkService = new CheckService();
        var playerTurn = new PlayerTurnService();
        var checkMateService = new CheckMateChecker();

        bool WhitePlayerTurn = true;

        chessBoard[4, 2] = 'q';

        chessBoard[8, 1] = 'K';
        chessBoard[7, 1] = ' ';
        chessBoard[8, 2] = 'P';
        chessBoard[8, 3] = 'P';
        chessBoard[8, 4] = 'P';
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
                case 'n':
                    figure = new BlackKnight(x, y);
                    break;
                case 'B':
                    figure = new WhiteBishop(x, y);
                    break;
                case 'b':
                    figure = new BlackBishop(x, y);
                    break;
                case 'Q':
                    figure = new WhiteQueen(x, y);
                    break;
                case 'q':
                    figure = new BlackQueen(x, y);
                    break;
                case 'K':
                    figure = new WhiteKing(x, y);
                    break;
                case 'k':
                    figure = new BlackKing(x, y);
                    break;
                default:
                    Console.WriteLine("Bad choice");
                    break;
            }


            if (WhitePlayerTurn)
            {
                if (playerTurn.WhitePlayerCanMove(figure))
                {

                }
                else
                {
                    Console.WriteLine("White player turn");
                    continue;
                }

            }
            else
            {
                if (!playerTurn.WhitePlayerCanMove(figure))
                {

                }
                else
                {
                    Console.WriteLine("Black player turn");
                    continue;
                }
            }
           
           


            if(figure is null)
            {
                Console.WriteLine("Bad input");
                return;
            }


            Console.WriteLine("Please choose where your figure should move: ");
            int xMove = int.Parse(Console.ReadLine());
            int yMove = int.Parse(Console.ReadLine());


            var move = new MoveManager(xMove, yMove);
            if (!move.ValidCordinates())
                return;


            var pawnManager = new PawnManager(figure, move);
            var gridManager = new GridManager(pawnManager);
            




            char[,] chessBoardCopy = (char[,])chessBoard.Clone();
            gridManager.ChangeBoardAfterChange(ref chessBoardCopy);

            int xPos = 0;
            int yPos = 0;


            if (WhitePlayerTurn)
            {
                if (!checkService.CanBlackPiecesCheck(chessBoardCopy, out xPos, out yPos))
                {
                    gridManager.ChangeBoardAfterChange(ref chessBoard);          
                    WhitePlayerTurn = false; 

                }
                else
                {
                    
                   if (checkMateService.IsCheckMateForBlack(chessBoardCopy, xPos, yPos))
                   {
                       Console.WriteLine("CHECKMATE");
                       return;
                   }
                   
                    Console.WriteLine("Cannot move here");
                    continue;
                }
                
            }
            else
            {
                if (!checkService.CanWhitePiecesCheck(chessBoardCopy, out xPos, out yPos))
                {
                    gridManager.ChangeBoardAfterChange(ref chessBoard);                  
                    WhitePlayerTurn = true;
                        
                }
                else
                {

                    
                    if (checkMateService.IsCheckMateForWhite(chessBoardCopy, xPos, yPos))
                    {
                        Console.WriteLine("CHECKMATE"); 
                        return;
                    }
                    

                    Console.WriteLine("Cannot move here");
                    continue;
                }
            }

            

            Console.WriteLine();
            Console.WriteLine();


            gridManager.ShowBoard(chessBoard);


        }

    


    }
}
