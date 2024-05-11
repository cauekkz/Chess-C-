using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class King : Piece
    {
        public King(Color color, Board board): base(color,board)
        {
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mtx = new bool[board.Rows, board.Cols];
            Position pos = new Position(0,0);

            
            pos.SetValues(position.Row + 1, position.Col);
            if(board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }
            
            pos.SetValues(position.Row -1, position.Col + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }


            pos.SetValues(position.Row, position.Col + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }


            pos.SetValues(position.Row + 1, position.Col + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }


            pos.SetValues(position.Row + 1, position.Col);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }


            pos.SetValues(position.Row + 1, position.Col - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }


            pos.SetValues(position.Row , position.Col - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }


            pos.SetValues(position.Row - 1, position.Col - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }

        }
        private bool CanMove(Position pos)
        {
            Piece p = board.GetPiece(pos);
            return p == null || p.color != color; 
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
