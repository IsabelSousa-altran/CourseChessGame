using System;
using BoardLayer;
using System.Text;

namespace ChessGameLayer
{
    class King : Piece
    {
        private ChessMatch match;

        public King(Color color, Board board, ChessMatch match) : base(color, board)
        {
            this.match = match;
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

        // Checks whether the tower in that position is eligible for castling
        private bool testRookForCastling(PositionBoard position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.MovementCount == 0;
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

            // #SPECIAL MOVE : Castling
            if (MovementCount == 0 && !match.MatchInCheck)
            {
                // Small castling
                // The king’s position must be three columns to the right relative to the rook
                PositionBoard rookPositionSmall = new PositionBoard(PositionBoard.Row, PositionBoard.Column + 3);
                if (testRookForCastling(rookPositionSmall))
                {
                    // The two houses between the king and the rook must be free
                    PositionBoard nextPosition = new PositionBoard(PositionBoard.Row, PositionBoard.Column + 1);
                    PositionBoard nextPosition2 = new PositionBoard(PositionBoard.Row, PositionBoard.Column + 2);
                    // The king can move to the second free house (next to the rook)
                    if (Board.Piece(nextPosition) == null && Board.Piece(nextPosition2) == null)
                    {
                        possibleMovimentsMatrix[PositionBoard.Row, PositionBoard.Column + 2] = true; 
                    }
                }

                // Big castling
                PositionBoard rookPositionBig = new PositionBoard(PositionBoard.Row, PositionBoard.Column - 4);
                if (testRookForCastling(rookPositionBig))
                {
                    // The three houses between the king and the rook must be free
                    PositionBoard nextPosition = new PositionBoard(PositionBoard.Row, PositionBoard.Column - 1);
                    PositionBoard nextPosition2 = new PositionBoard(PositionBoard.Row, PositionBoard.Column - 2);
                    PositionBoard nextPosition3 = new PositionBoard(PositionBoard.Row, PositionBoard.Column - 2);
                    
                    // The king can move to the second free house 
                    if (Board.Piece(nextPosition) == null && Board.Piece(nextPosition2) == null && Board.Piece(nextPosition3) == null)
                    {
                        possibleMovimentsMatrix[PositionBoard.Row, PositionBoard.Column - 2] = true;
                    }
                }
            }

            return possibleMovimentsMatrix;
        }
    }
}
