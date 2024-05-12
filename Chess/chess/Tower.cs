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
        public override bool[,] PossibleMovements()
        {
            bool[,] mtx = new bool[board.Rows, board.Cols];
            
            Position pos = new Position(position.Row - 1, position.Col);
            while (board.ValidPosition(pos) && CanMove(pos))
            {

                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;
                }
                pos.Row--;
            }

            pos = new Position(position.Row + 1, position.Col);
            while (board.ValidPosition(pos) && CanMove(pos))
            {

                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;
                }
                pos.Row++;
            }

            pos = new Position(position.Row, position.Col + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {

                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;
                }
                pos.Col++;
            }

            pos = new Position(position.Row, position.Col - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {

                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;
                }
                pos.Col--;
            }
            return mtx;




        }

        private bool CanMove(Position pos)
        {
            Piece p = board.GetPiece(pos);
            return p == null || p.color != color;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
