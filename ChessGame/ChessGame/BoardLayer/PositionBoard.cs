using System;
using System.Collections.Generic;
using System.Text;

namespace BoardLayer
{
    class PositionBoard
    {
        public int Rows { get; set; }
        public int Columms { get; set; }

        public PositionBoard(int rows, int columms)
        {
            Rows = rows;
            Columms = columms;
        }

        public override string ToString()
        {
            return Rows 
                + ", "
                + Columms;
        }
    }
}
