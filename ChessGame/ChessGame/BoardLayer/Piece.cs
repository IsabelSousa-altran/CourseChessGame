using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    abstract class Piece
    {
        public PositionBoard PositionBoard { get; set; }
        public Color Color { get; protected set; }
        public int MovementCount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece( Color color, Board board)
        {
            // The piece has no position yet, it is null (the one who places the piece is the board).
            PositionBoard = null;
            Color = color;
            MovementCount = 0;
            Board = board;
        }

        public void IncreaseMovementCount()
        {
            MovementCount++;
        }

        public void DecreaseMovementCount()
        {
            MovementCount--;
        }

        // It will check if there are any possible moves
        public bool ThereArePossibleMovements()
        {
            bool[,] matrixPossibleMoves = PossibleMoviments();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrixPossibleMoves[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(PositionBoard position)
        {
            return PossibleMoviments()[position.Row, position.Column];
        }

        // The movement rule depends on each piece, so it is an abstract method.
        // We will have a matrix of true and false that shows us where it is possible to move that piece
        public abstract bool[,] PossibleMoviments();

       
    }
}
