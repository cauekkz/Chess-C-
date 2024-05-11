using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class ChessMatch
    {
        public Board board {  get; private set; }
        private int _turn;
        private Color _player;
        public bool Finished { get; private set; }


        public ChessMatch()
        {
            board = new Board(8,8);
            _turn = 0;
            _player = Color.White;
            InitializePieces();
            Finished = false;
        }
        
        public void MoveExec(Position origin, Position destination)
        {

            Piece p = board.RemovePiece(origin);

            p.IncreaseMovement();
            Piece  cptP = board.RemovePiece(destination);
            board.SetPiecePosition(p,destination);
            
         



        }
        private void InitializePieces()
        {
            board.SetPiecePosition(new Tower(Color.Black, board), new ChessPosition('c',1).ToPosition());
        }
    }
}
