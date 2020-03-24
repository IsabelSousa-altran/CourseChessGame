﻿using System;
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

        public Piece( Color color, Board board)
        {
            // The piece has no position yet, it is null (the one who places the piece is the board)
            PositionBoard = null;
            Color = color;
            MoveCount = 0;
            Board = board;
        }
    }
}