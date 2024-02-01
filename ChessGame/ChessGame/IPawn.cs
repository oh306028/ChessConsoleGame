using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public interface IPawn
    {
        int positionX { get; set; }
        int positionY { get; set; }
        char symbol { get; set; }
        bool CanMove(int x, int y);
        bool Allive();
            

    }
}
