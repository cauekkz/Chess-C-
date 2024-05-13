using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "N";
        }
        private bool CanMove(Position pos)
        {
            Piece p = board.GetPiece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mtx = new bool[board.Rows, board.Cols];

            Position pos = new Position(0,0);
            
            pos = new Position(position.Row - 1, position.Col - 2);
            if(board.ValidPosition(pos) && CanMove(pos)) 
            {
                mtx[pos.Row,pos.Col] = true;
            
            }

            pos = new Position(position.Row - 2, position.Col - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }


            pos = new Position(position.Row - 2, position.Col + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }


            pos = new Position(position.Row - 1, position.Col + 2);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }


            pos = new Position(position.Row + 1, position.Col + 2);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }


            pos = new Position(position.Row + 2, position.Col + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }


            pos = new Position(position.Row + 2, position.Col - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }


            pos = new Position(position.Row + 1, position.Col - 2);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;

            }
            return mtx;


        }

    }
}
