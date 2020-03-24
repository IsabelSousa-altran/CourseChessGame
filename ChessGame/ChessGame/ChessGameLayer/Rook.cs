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
    }
}
