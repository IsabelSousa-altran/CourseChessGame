using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class PositionBoard
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public PositionBoard(int row, int columm)
        {
            Row = row;
            Column = columm;
        }

        public override string ToString()
        {
            return Row 
                + ", "
                + Column;
        }
    }
}
