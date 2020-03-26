using System;
using System.Collections.Generic;
using BoardLayer;

namespace ChessGameLayer
{
    class Pown : Piece
    {
        public Pown(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool thereIsEnemy(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }

        private bool free(PositionBoard position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            // It will save all possible moves for the king. 
            // It can move all around him.
            bool[,] possibleMovimentsMatrix = new bool[Board.Rows, Board.Columns];

            PositionBoard position = new PositionBoard(0, 0);

            if (Color == Color.White)
            {
                // Can move up one house if the house is free.
                position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column);
                if (Board.PositionIsValid(position) && free(position))
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }

                // Can move two houses up if the house is free and if it is the first move of the pawn.
                position.SetPositionValues(PositionBoard.Row - 2, PositionBoard.Column);
                if (Board.PositionIsValid(position) && free(position) && MovementCount == 0)
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }

                // Can walk on diagonals if there is an enemy.
                position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column - 1);
                if (Board.PositionIsValid(position) && thereIsEnemy(position))
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }

                position.SetPositionValues(PositionBoard.Row - 1, PositionBoard.Column + 1);
                if (Board.PositionIsValid(position) && thereIsEnemy(position))
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }
            }
            else
            {
                // Can move down one house if the house is free.
                position.SetPositionValues(position.Row + 1, position.Column);
                if (Board.PositionIsValid(position) && free(position))
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }

                // Can move two houses down if the house is free and if it is the first move of the pawn.
                position.SetPositionValues(position.Row + 2, position.Column);
                if (Board.PositionIsValid(position) && free(position) && MovementCount == 0)
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }

                // Can walk on diagonals if there is an enemy.
                position.SetPositionValues(position.Row + 1, position.Column - 1);
                if (Board.PositionIsValid(position) && thereIsEnemy(position))
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }

                position.SetPositionValues(position.Row + 1, position.Column + 1);
                if (Board.PositionIsValid(position) && thereIsEnemy(position))
                {
                    possibleMovimentsMatrix[position.Row, position.Column] = true;
                }
            }
            return possibleMovimentsMatrix;
        }
    }
}

