using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
     abstract internal class Piece
    {
        public Position position {  get; set; }
        public Color color { get; protected set; }
        public int AmtMovements { get; protected set; }
        public Board board {  get; protected set; }

        public Piece(Color color, Board board)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            AmtMovements = 0;
        }
        public abstract bool[,] PossibleMovements();
        public bool ExistpossibleMoves()
        {
            bool[,] mtx = PossibleMovements();
            for(int i = 0; i < board.Rows;  i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    if (mtx[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveToPosition(Position position)
        {
            return PossibleMovements()[position.Row, position.Col];
        }
        public void IncreaseMovement()
        {
            AmtMovements++;
        }
        public void DecrementMovement()
        {
            AmtMovements--  ;
        }

    }
}
