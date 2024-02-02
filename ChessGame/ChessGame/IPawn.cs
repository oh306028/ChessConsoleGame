using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public interface IPawn
    {
        int rowPosition { get; set; }
        int columnPosition { get; set; }
        char symbol { get; set; }
        bool CanMove(int x, int y);
        bool Allive();

        bool CanAttack(int x, int y);
            

    }
}   
