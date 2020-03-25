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

        // The movement rule depends on each piece, so it is an abstract method.
        // We will have a matrix of true and false that shows us where it is possible to move that piece
        public abstract bool[,] PossibleMoviments();

        public void IncreaseMovementCount()
        {
            MovementCount++;
        }
    }
}
