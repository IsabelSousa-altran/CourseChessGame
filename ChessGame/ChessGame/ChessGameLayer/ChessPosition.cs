using BoardLayer;

namespace ChessGameLayer
{
    class ChessPosition
    {
        public char Columm { get; set; }
        public int Row { get; set; }

        public ChessPosition(char columm, int row)
        {
            Columm = columm;
            Row = row;
        }

        // Chess positions are different from those used internally in the matrix.
        // The lines go from 1 to 8 and the columns from A to H 
        // and start counting from the lower left corner, contrary to the matrix that starts in the upper left corner
        public PositionBoard ChessPositionToMatrixPosition()
        {
            // 
            return new PositionBoard(8 - Row, Columm - 'a');
        }

        public override string ToString()
        {
            return "" 
                + Columm
                + Row;
        }
    }
}
