using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Tower : Piece
    {
        public Tower(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
