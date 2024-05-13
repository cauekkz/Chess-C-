using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position pos)
        {
            Piece p = board.GetPiece(pos);
            return p != null && p.color != color;

        }

        private bool Free(Position pos)
        {
            return board.GetPiece(pos) == null;
        }


        public override bool[,] PossibleMovements()
        {

            bool[,] mtx = new bool[board.Rows, board.Cols];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.SetValues(position.Row - 1, position.Col);
                if (board.ValidPosition(pos) && Free(pos))
                {
                    mtx[pos.Row, pos.Col] = true;
                }

                pos.SetValues(position.Row - 2, position.Col);
                if (board.ValidPosition(pos) && Free(pos) && AmtMovements == 0)
                {
                    mtx[pos.Row, pos.Col] = true;
                }
                pos.SetValues(position.Row - 1, position.Col - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mtx[pos.Row, pos.Col] = true;
                }

                pos.SetValues(position.Row - 1, position.Col + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mtx[pos.Row, pos.Col] = true;
                }
            }
            else
            {
                pos.SetValues(position.Row + 1, position.Col);
                if (board.ValidPosition(pos) && Free(pos))
                {
                    mtx[pos.Row, pos.Col] = true;
                }

                pos.SetValues(position.Row + 2, position.Col);
                if (board.ValidPosition(pos) && Free(pos) && AmtMovements == 0)
                {
                    mtx[pos.Row, pos.Col] = true;
                }
                pos.SetValues(position.Row + 1, position.Col - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mtx[pos.Row, pos.Col] = true;
                }

                pos.SetValues(position.Row +  1, position.Col + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mtx[pos.Row, pos.Col] = true;
                }


            }

            return mtx;
        }
    }
}
