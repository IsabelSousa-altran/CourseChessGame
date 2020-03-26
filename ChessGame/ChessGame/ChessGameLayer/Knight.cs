using System;
using System.Collections.Generic;
using BoardLayer;

namespace ChessGameLayer
{
    class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "k";
        }

        private bool youCanMove(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            // The piece will only be able to move if the chosen position is free or with a piece of the opposite color.
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            // It will save all possible moves for the knight. 
            bool[,] possibleMovimentsMatrix = new bool[Board.Rows, Board.Columns];

            PositionBoard position = new PositionBoard(0, 0);

           // Above
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column - 2);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // NorthEast
            position.SetPositionValues(PositionBoard.Row - 2, PositionBoard.Column - 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Right
            position.SetPositionValues(PositionBoard.Row - 2, PositionBoard.Column + 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // South-west
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column + 2);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Below
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column + 2);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // South-west
            position.SetPositionValues(PositionBoard.Row + 2, PositionBoard.Column + 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Left
            position.SetPositionValues(PositionBoard.Row + 2, PositionBoard.Column - 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Northwest
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column - 2);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }
            return possibleMovimentsMatrix;
        }
    }
}

