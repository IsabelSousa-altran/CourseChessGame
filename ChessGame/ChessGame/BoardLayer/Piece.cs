using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class Piece
    {
        public PositionBoard PositionBoard { get; set; }
        public Color Color { get; protected set; }
        public int MoveCount { get; protected set; }
        public Board Board { get; set; }

        public Piece(PositionBoard position, Color color, Board board)
        {
            PositionBoard = position;
            Color = color;
            MoveCount = 0;
            Board = board;
        }
    }
}
