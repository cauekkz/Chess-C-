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

        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;




        public ChessMatch()
        {

            board = new Board(8,8);
            turn = 0;
            player = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            InitializePieces();
            Finished = false;
        }
        
        public void MoveExec(Position origin, Position destination)
        {

            Piece p = board.RemovePiece(origin);

            p.IncreaseMovement();
            Piece  cptP = board.RemovePiece(destination);
            board.SetPiecePosition(p,destination);
            if (cptP != null)
            {
                captured.Add(cptP);
            }
            

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
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> ax = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if(x.color == color)
                {
                    ax.Add(x);
                }
            }
            return ax;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> ax = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    ax.Add(x);
                }
            }
            ax.ExceptWith(CapturedPieces(color));
            return ax;
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
        public void PlaceNewPiece(char col, int row, Piece p)
        {
            board.SetPiecePosition(p, new ChessPosition(col, row).ToPosition());
            pieces.Add(p);
        }
        private void InitializePieces()
        {
            PlaceNewPiece('c', 1, new Tower(Color.Black, board));
            PlaceNewPiece('f', 1, new Tower(Color.White, board));



        }
    }
}
