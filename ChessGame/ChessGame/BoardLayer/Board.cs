using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class Board
    {
        public int Rows { get; set; }
        public int Columms { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columms)
        {
            Rows = rows;
            Columms = columms;
            this.pieces = new Piece[rows,columms];
        }

        // Method that will return a piece
        public Piece Piece(int row, int columm)
        {
            return pieces[row, columm];
        }


    }
}
