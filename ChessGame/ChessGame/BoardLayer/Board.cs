using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows,columns];
        }

        // Method that will return a piece
        public Piece Piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece Piece(PositionBoard position)
        {
            return pieces[position.Row, position.Column];
        }

        // Checks whether a piece exists in a given position
        public bool ThereIsAPiece(PositionBoard position)
        {
            // If there is a position validation error, the error message is displayed
            ValidatePositionException(position);

            // If this is true, there is a piece in this position
            return Piece(position) != null;
        }

        // Places a piece "piece" in the position "position"(has row and column from PositionBoard).
        public void PlacePieceOnBoard (Piece piece, PositionBoard position)
        {
            // If method "ThereIsAPiece" returns true, then an error message is displayed. 
            // In this case that a piece already exists in that position
            if (ThereIsAPiece(position))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            // Places the piece in the matrix
            pieces[position.Row, position.Column] = piece;

            // The position of the piece is now "position"
            piece.PositionBoard = position;
        }

        public Piece RemovePiece(PositionBoard position)
        {   
            // There is no piece in this position to be removed.
            if (Piece(position) == null)
            {
                return null;
            }
            // If the previous "if" passed then there is a piece in that position.
            Piece pieceToRemove = Piece(position);
            // Now the position of that piece will cease to exist, it was removed from the board.
            pieceToRemove.PositionBoard = null;
            // The position on the board is null.
            pieces[position.Row, position.Column] = null;
            return pieceToRemove;
        }

        // We have a board that is 8 by 8, so we cannot allow the position of the pieces to be outside these limits.
        // In this case, the line cannot be less than zero or greater than or equal to the value stipulated in the variable "lines", in this case 8.
        // The same in the case of the columns.
        // Tests whether the position is valid or not.
        public bool PositionIsValid(PositionBoard position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        // If the position is not valid (verified in the previous method - PositionIsValid), 
        // it will launch an exception message.
        public void ValidatePositionException(PositionBoard position)
        {
            if (!PositionIsValid(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }

    }
}
