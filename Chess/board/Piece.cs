using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Piece
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

        public void IncreaseMovement()
        {
            AmtMovements++;
        }

    }
}
