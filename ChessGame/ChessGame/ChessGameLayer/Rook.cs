using System;
using BoardLayer;
using System.Text;

namespace ChessGameLayer
{
    class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool youCanMove(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            // The piece will only be able to move if the chosen position is free or with a piece of the opposite color.
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            // It will save all possible moves for the root. 
            bool[,] possibleMovimentsMatrix = new bool[Board.Rows, Board.Columns];

            PositionBoard position = new PositionBoard(0, 0);

            // Above
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row = position.Row - 1;
            }

            // Below
            position.SetPositionValues(PositionBoard.Row + 1, PositionBoard.Column);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row = position.Row + 1;
            }

            // Right
            position.SetPositionValues(PositionBoard.Row, PositionBoard.Column + 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            // Left
            position.SetPositionValues(PositionBoard.Row, PositionBoard.Column - 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }
            return possibleMovimentsMatrix;
        }
    }
}
