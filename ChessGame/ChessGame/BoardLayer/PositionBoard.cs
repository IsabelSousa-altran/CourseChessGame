using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class PositionBoard
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public PositionBoard(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetPositionValues(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return Row 
                + ", "
                + Column;
        }
    }
}
