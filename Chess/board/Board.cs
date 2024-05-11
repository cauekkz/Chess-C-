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
        public int Rows { get; set; }
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
        public Piece GetPiece(Position p)
        {
            return _pieces[p.Row, p.Col];
        }
        public void SetPiecePosition(Piece p, Position pos)
        {
            if (PieceExist(pos))
            {
                throw new BoardException("already exist an piece on this position");
            }
            _pieces[pos.Row, pos.Col] = p;
            p.position = pos;
        }
        public bool PieceExist(Position p)
        {
            PositionValid(p);
            return GetPiece(p) != null;
        }
        public bool ValidPosition(Position p)
        {
            if (p.Row < 0 || p.Col < 0 || p.Row >= Rows || p.Col >= Cols)
                return false;
            return true;
        }
        
        public void PositionValid(Position p)
        {
            if (!ValidPosition(p))
            {
                throw new BoardException("Invalid position");
            }
        }
    }
}
