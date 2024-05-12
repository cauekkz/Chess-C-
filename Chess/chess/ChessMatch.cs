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
        public int turn { get; private set; }
        public Color player { get; private set; }
        public bool Finished { get; private set; }


        public ChessMatch()
        {
            board = new Board(8,8);
            turn = 0;
            player = Color.White;
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
        public void MakePlay(Position origin, Position destination)
        {
            MoveExec(origin, destination);
            turn++;
            ChangePlayer();

        }
        private void ChangePlayer()
        {
            if (player == Color.White)
            {
                player = Color.Black;
            }
            else
            {
                player = Color.White;
            }
        }
        public void ValidOriginPosition(Position p)
        {
            if (board.GetPiece(p) == null)
            {
                throw new BoardException("Not exist piece on this origin");
            }
            if(player != board.GetPiece(p).color)
            {
                throw new BoardException("it is not your piece");
            }
            if (!board.GetPiece(p).ExistpossibleMoves())
            {
                throw new BoardException("no movements possible");

            }
        }
        public void ValidDestinationPosition(Position origin,Position destination)
        {
            if (!board.GetPiece(origin).CanMoveToPosition(destination)) 
            {
                throw new BoardException("Destination Position Invalid");
            }
        }
        private void InitializePieces()
        {
            board.SetPiecePosition(new Tower(Color.Black, board), new ChessPosition('c',1).ToPosition());

            board.SetPiecePosition(new King(Color.Black, board), new ChessPosition('e', 2).ToPosition());
            board.SetPiecePosition(new King(Color.Black, board), new ChessPosition('d', 2).ToPosition());

            board.SetPiecePosition(new Tower(Color.White, board), new ChessPosition('a', 1).ToPosition());
            board.SetPiecePosition(new Tower(Color.Black, board), new ChessPosition('c', 7).ToPosition());


        }
    }
}
