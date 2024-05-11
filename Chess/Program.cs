using board;
using chess;
using Chess;


Board b = new Board(8, 8);
b.SetPiecePosition(new Tower(Color.Black, b), new Position(0, 0)); 
b.SetPiecePosition(new King(Color.White, b), new Position(0, 1));
Screen.PrintBoard(b);

ChessPosition cPos = new ChessPosition('a', 1);
Console.WriteLine(cPos.ToPosition());
