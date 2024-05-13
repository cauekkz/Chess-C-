using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        private bool CanMove(Position pos)
        {
            Piece p = board.GetPiece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mtx = new bool[board.Rows, board.Cols];

            Position pos = new Position(0, 0);
            pos.SetValues(position.Row - 1, position.Col - 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(position.Row - 1, position.Col - 1);

            }

            pos.SetValues(position.Row - 1, position.Col + 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(position.Row - 1, position.Col + 1);

            }

            pos.SetValues(position.Row + 1, position.Col + 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(position.Row + 1, position.Col + 1);

            }

            pos.SetValues(position.Row + 1, position.Col - 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(position.Row + 1, position.Col - 1);

            }

            return mtx;
        }
    }
}
