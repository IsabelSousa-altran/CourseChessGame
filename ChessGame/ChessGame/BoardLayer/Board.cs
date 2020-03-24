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

        // Places a piece "piece" in the position "position"(has row and columm from PositionBoard)
        public void PlacePieceOnBoard (Piece piece, PositionBoard position)
        { 
            // Places the piece in the matrix
            pieces[position.Row, position.Columm] = piece;

            // The position of the piece is now "position"
            piece.PositionBoard = position;
        }

    }
}
