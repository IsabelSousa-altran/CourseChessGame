using System;
using System.Collections.Generic;
using BoardLayer;

namespace ChessGameLayer
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool youCanMove(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            // The piece will only be able to move if the chosen position is free or with a piece of the opposite color.
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            // It will save all possible moves for the queen. 
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
                PositionBoard.SetPositionValues(position.Row - 1, position.Column);
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
                PositionBoard.SetPositionValues(position.Row + 1, position.Column);
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
                PositionBoard.SetPositionValues(position.Row, position.Column + 1);

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
                PositionBoard.SetPositionValues(position.Row, position.Column - 1);
            }

            // Northwest
            position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column - 1);
            while (Board.PositionIsValid(position) && youCanMove(position))
            {
                possibleMovimentsMatrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetPositionValues(position.Row - 1, position.Column - 1);
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



