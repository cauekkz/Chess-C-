using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Board
    {
        public int Rows {  get; set; }
        public int Cols { get; set; }

        private Pieces[,] pieces;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            pieces = new Pieces[Rows, Cols]; 
        }
    }
}
