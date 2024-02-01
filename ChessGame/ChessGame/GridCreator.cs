﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChessGame
{
    public class GridCreator
    {
        private Grid _grid = new Grid();

        private char[,] board = new char[9,9];


        public char[,] InitGrid()
        {
            

            board[1, 1] = 'r';
            board[1, 2] = 'n';
            board[1, 3] = 'b';
            board[1, 4] = 'q';
            board[1, 5] = 'k';
            board[1, 6] = 'b';
            board[1, 7] = 'n';
            board[1, 8] = 'r';

            for(int i = 1; i < 9; i++)
            {
                board[2, i] = 'p';
            }


            board[8, 1] = 'R';
            board[8, 2] = 'N';
            board[8, 3] = 'B';
            board[8, 4] = 'Q';
            board[8, 5] = 'K';
            board[8, 6] = 'B';
            board[8, 7] = 'N';
            board[8, 8] = 'R';

            for (int i = 1; i < 9; i++)
            {
                board[7, i] = 'P';
            }

            board[0, 0] = ' ';
            board[0, 1] = 'A';
            board[0, 2] = 'B';
            board[0, 3] = 'C';
            board[0, 4] = 'D';
            board[0, 5] = 'E';
            board[0, 6] = 'F';
            board[0, 7] = 'G';
            board[0, 8] = 'H';

            board[1, 0] = '1';
            board[2, 0] = '2';
            board[3, 0] = '3';
            board[4, 0] = '4';
            board[5, 0] = '5';
            board[6, 0] = '6';
            board[7, 0] = '7';
            board[8, 0] = '8';


            return board;
        }

        public void ShowBoard()
        {
            for (int i = 0; i < _grid.collumns; i++)
            {
                for (int j = 0; j < _grid.rows; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }
        }

        public char[,] GetBoard()
        {
            return board;
        }

    }
}
