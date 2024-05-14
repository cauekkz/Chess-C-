using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Queen : Piece
    {

        public Queen(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "Q";
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
                pos.SetValues(pos.Row - 1, pos.Col - 1);

            }
            Console.WriteLine("d");

            pos.SetValues(position.Row - 1, position.Col + 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(pos.Row - 1, pos.Col + 1);

            }

            pos.SetValues(position.Row + 1, position.Col + 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(pos.Row + 1, pos.Col + 1);

            }

            pos.SetValues(position.Row + 1, position.Col - 1);

            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != color)
                {
                    break;

                }
                pos.SetValues(pos.Row + 1, pos.Col - 1);

            }

            pos = new Position(position.Row - 1, position.Col);
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
    }
}
