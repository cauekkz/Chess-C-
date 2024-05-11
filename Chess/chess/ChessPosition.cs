using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class ChessPosition
    {
        public char Col {  get; set; }
        public int Row { get; set; }
        public ChessPosition(char col, int row)
        {
            Col = col;
            Row = row;

        }
        public Position ToPosition()
        {
            return new Position(8 - Row, Col - 'a');
        }
        public override string ToString()
        {
            return "" + Col + Row;
        }

    }
}
