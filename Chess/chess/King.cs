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
        private ChessMatch Match;
        public King(Color color, Board board, ChessMatch match) : base(color,board)
        {
            Match = match;
        }
        private bool TestRookPosition(Position pos)
        {
            Piece p = board.GetPiece(pos);
            return p != null && p is Rook && p.color == color && p.AmtMovements == 0;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mtx = new bool[board.Rows, board.Cols];
            Position pos = new Position(0,0);

            
            pos.SetValues(position.Row - 1, position.Col);
            if(board.ValidPosition(pos) && CanMove(pos))
            {
                mtx[pos.Row, pos.Col] = true;
            }
            
            pos.SetValues(position.Row - 1, position.Col + 1);
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
            // #special moves
            if (AmtMovements == 0 && !Match.check)
            {
                // #Castle Kingside
                Position posR = new Position(position.Row, position.Col + 3);
                if (TestRookPosition(posR))
                {
                    Position p1 = new Position(position.Row, position.Col + 1);
                    Position p2 = new Position(position.Row, position.Col + 2);
                    if (board.GetPiece(p1) == null && board.GetPiece(p2) == null)
                    {
                        mtx[position.Row, position.Col + 2] = true;
                    }

                }

                // #Castle Queenside
                Position posR2 = new Position(position.Row, position.Col - 4);
                if (TestRookPosition(posR))
                {
                    Position p1 = new Position(position.Row, position.Col - 1);
                    Position p2 = new Position(position.Row, position.Col - 2);
                    Position p3 = new Position(position.Row, position.Col - 3);

                    if (board.GetPiece(p1) == null && board.GetPiece(p2) == null  && board.GetPiece(p3) == null)
                    {
                        mtx[position.Row, position.Col - 2] = true;
                    }

                }
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
            return "K";
        }

        
        
    }
}
