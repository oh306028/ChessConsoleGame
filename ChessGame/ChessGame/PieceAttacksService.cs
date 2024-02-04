using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PieceAttacksService
    {
        
        private IPawn _pawn;
        private List<char>BlackPieces = new List<char>(){'p','r','n','q','k','b'};
        private List<char> WhitePieces = new List<char>() { 'P', 'R', 'N', 'Q', 'K', 'B' };


        public PieceAttacksService(IPawn pawn)
        {
            _pawn = pawn;
        }



        public bool IsAttacking(char[,] board, int xMove, int yMove)    
        {
            if (BlackPieces.Contains(_pawn.symbol))
            {
                  foreach (var piece in WhitePieces)
                        if (board[xMove,yMove] == piece)
                        {
                           return true;
                        }                        
            }
            else
            {
                   foreach (var piece in BlackPieces)
                       if (board[xMove, yMove] == piece)
                       {
                           return true;
                       }
                
            }
           
            return false;
        }



    }
}
