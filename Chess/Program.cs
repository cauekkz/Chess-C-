using board;
using chess;
using Chess;


Board b = new Board(8,8);
b.SetPiecePosition(new Tower(Color.Preta,b), new Position(0, 0)); ;
Screen.PrintBoard(b);
