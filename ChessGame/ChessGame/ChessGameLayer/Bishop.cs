using System;
using System.Collections.Generic;
using BoardLayer;

namespace ChessGameLayer
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool youCanMove(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            // The piece will only be able to move if the chosen position is free or with a piece of the opposite color.
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            // It will save all possible moves for the bishop - walk diagonals. 
            bool[,] possibleMovimentsMatrix = new bool[Board.Rows, Board.Columns];

            PositionBoard position = new PositionBoard(0, 0);

            // Northwest
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column - 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetPositionValues(position.Row - 1, position.Column-1);
            }

            // NorthEast
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column + 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetPositionValues(position.Row - 1, position.Column + 1);
            }

            // Southeast
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column + 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetPositionValues(position.Row + 1, position.Column + 1);
            }

            // South-west
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column - 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetPositionValues(position.Row + 1, position.Column - 1);
            }
            return possibleMovimentsMatrix;
        }
    }
}

