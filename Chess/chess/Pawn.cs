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
        private ChessMatch Match;
        public Pawn(Color color, Board board, ChessMatch match) : base(color, board)
        {
            Match = match;
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
                //Special move
                if (position.Row == 3)
                {
                    Position left = new Position(position.Row, position.Col - 1);
                    if(board.ValidPosition(left) && ExistEnemy(left) && board.GetPiece(left) == Match.vulnerableEnPassant)
                    {
                        mtx[left.Row - 1, left.Col] = true;
                    }

                    Position right = new Position(position.Row, position.Col + 1);
                    if (board.ValidPosition(right) && ExistEnemy(right) && board.GetPiece(right) == Match.vulnerableEnPassant)
                    {
                        mtx[right.Row - 1, right.Col] = true;
                    }
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
                //special move

                if (position.Row == 4)
                {
                    Position left = new Position(position.Row, position.Col - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.GetPiece(left) == Match.vulnerableEnPassant)
                    {
                        mtx[left.Row + 1, left.Col] = true;
                    }

                    Position right = new Position(position.Row, position.Col + 1);
                    if (board.ValidPosition(right) && ExistEnemy(right) && board.GetPiece(right) == Match.vulnerableEnPassant)
                    {
                        mtx[right.Row + 1, right.Col] = true;
                    }
                }



            }

            return mtx;
        }
    }
}
