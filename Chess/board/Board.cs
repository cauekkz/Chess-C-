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

        private Piece[,] _pieces;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _pieces = new Piece[Rows, Cols]; 
        }
        public Piece GetPiece(int i, int j)
        {
            return _pieces[i, j];
        }
        public void SetPiecePosition(Piece p, Position pos)
        {
            _pieces[pos.Row, pos.Col] = p;
            p.position = pos;
        }
    }
}
