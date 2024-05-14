using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color player { get; private set; }
        public bool Finished { get; private set; }

        public bool check { get; private set; }

        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;




        public ChessMatch()
        {

            board = new Board(8, 8);
            turn = 0;
            player = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            InitializePieces();
            Finished = false;
            check = false;

        }

        public Piece MoveExec(Position origin, Position destination)
        {

            Piece p = board.RemovePiece(origin);

            p.IncreaseMovement();
            Piece cptP = board.RemovePiece(destination);
            board.SetPiecePosition(p, destination);
            if (cptP != null)
            {
                captured.Add(cptP);
            }
            return cptP;



        }
        public void MakePlay(Position origin, Position destination)
        {
            Piece cptP = MoveExec(origin, destination);

            if (Ischeck(player))
            {
                UnmakePlay(origin, destination, cptP);
                throw new BoardException("You can't be in check");
            }

            if (Ischeck(Adversary(player)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (CheckMate(Adversary(player)))
            {
                Finished = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }


        }
        public void UnmakePlay(Position origin, Position destination, Piece cptP)
        {
            Piece p = board.RemovePiece(destination);
            p.DecrementMovement();
            if (cptP != null)
            {
                board.SetPiecePosition(cptP, destination);
                captured.Remove(cptP);
            }
            board.SetPiecePosition(p, origin);
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
        private Color Adversary(Color c)
        {
            if (c == Color.Black)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        public bool Ischeck(Color c)
        {
            Piece k = GetKing(c);
            if (k == null)
                throw new BoardException("Not has king with this color on board");

            foreach (Piece x in PiecesInGame(Adversary(c)))
            {
                bool[,] mtx = x.PossibleMovements();

                if (mtx[k.position.Row, k.position.Col])
                    return true;

            }
            return false;
        }
        public bool CheckMate(Color c)
        {
            if (!Ischeck(c))
                return false;
            foreach (Piece x in PiecesInGame(c))
            {
                bool[,] mtx = x.PossibleMovements();
                for (int i = 0; i < board.Rows; i++)
                {
                    for (int j = 0; j < board.Cols; j++)
                    {
                        if (mtx[i, j])
                        {
                            Position ori = x.position;
                            Position des = new Position(i, j);
                            Piece cptP = MoveExec(ori, des);
                            bool TestCheck = Ischeck(c);
                            UnmakePlay(ori, des, cptP);
                            if (!TestCheck)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            return true;

        }
        private Piece GetKing(Color c)
        {
            foreach (Piece x in PiecesInGame(c))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> ax = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
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
            if (player != board.GetPiece(p).color)
            {
                throw new BoardException("it is not your piece");
            }
            if (!board.GetPiece(p).ExistpossibleMoves())
            {
                throw new BoardException("no movements possible");

            }
        }
        public void ValidDestinationPosition(Position origin, Position destination)
        {
            if (!board.GetPiece(origin).PossibleMovement(destination))
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
            PlaceNewPiece('a', 1, new Rook(Color.White, board));
            PlaceNewPiece('b', 1, new Knight(Color.White, board));
            PlaceNewPiece('c', 1, new Bishop(Color.White, board));
            PlaceNewPiece('d', 1, new Queen(Color.White, board));
            PlaceNewPiece('e', 1, new King(Color.White, board));
            PlaceNewPiece('f', 1, new Bishop(Color.White, board));
            PlaceNewPiece('g', 1, new Knight(Color.White, board));
            PlaceNewPiece('h', 1, new Rook(Color.White, board));
            PlaceNewPiece('a', 2, new Pawn(Color.White, board));
            PlaceNewPiece('b', 2, new Pawn(Color.White, board));
            PlaceNewPiece('c', 2, new Pawn(Color.White, board));
            PlaceNewPiece('d', 2, new Pawn(Color.White, board));
            PlaceNewPiece('e', 2, new Pawn(Color.White, board));
            PlaceNewPiece('f', 2, new Pawn(Color.White, board));
            PlaceNewPiece('g', 2, new Pawn(Color.White, board));
            PlaceNewPiece('h', 2, new Pawn(Color.White, board));

            PlaceNewPiece('a', 8, new Rook(Color.Black, board));
            PlaceNewPiece('b', 8, new Knight(Color.Black, board));
            PlaceNewPiece('c', 8, new Bishop(Color.Black, board));
            PlaceNewPiece('d', 8, new Queen(Color.Black, board));
            PlaceNewPiece('e', 8, new King(Color.Black, board));
            PlaceNewPiece('f', 8, new Bishop(Color.Black, board));
            PlaceNewPiece('g', 8, new Knight(Color.Black, board));
            PlaceNewPiece('h', 8, new Rook(Color.Black, board));
            PlaceNewPiece('a', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('b', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('c', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('d', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('e', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('f', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('g', 7, new Pawn(Color.Black, board));
            PlaceNewPiece('h', 7, new Pawn(Color.Black, board));









        }
    }
}
