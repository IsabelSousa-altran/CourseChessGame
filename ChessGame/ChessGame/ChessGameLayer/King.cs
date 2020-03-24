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
    }
}
