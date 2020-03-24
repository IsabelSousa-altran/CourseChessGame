using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class PositionBoard
    {
        public int Row { get; set; }
        public int Columm { get; set; }

        public PositionBoard(int row, int columm)
        {
            Row = row;
            Columm = columm;
        }

        public override string ToString()
        {
            return Row 
                + ", "
                + Columm;
        }
    }
}
