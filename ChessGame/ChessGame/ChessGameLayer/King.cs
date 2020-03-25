using System;
using BoardLayer;
using System.Text;

namespace ChessGameLayer
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        // It will check if the king can move to the given position.
        private bool youCanMove(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            // The piece will only be able to move if the chosen position is free or with a piece of the opposite color.
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            // It will save all possible moves for the king. 
            // It can move all around him.
            bool[,] possibleMovimentsMatrix = new bool[Board.Rows, Board.Columns];

            PositionBoard position = new PositionBoard(0, 0);

            // Above
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // NorthEast
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column + 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Right
            position.SetPositionValues(PositionBoard.Row, PositionBoard.Column + 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Southeast
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column + 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Below
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // South-west
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column - 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Left
            position.SetPositionValues(PositionBoard.Row, PositionBoard.Column - 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }

            // Northwest
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column - 1);
            if (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
            }
            return possibleMovimentsMatrix;
        }
    }
}
