using board;
using chess;
using Chess;

ChessMatch match = new ChessMatch();
Screen.PrintBoard(match.board);
while (!match.Finished)
{
    Console.Clear();
    Screen.PrintBoard(match.board);
    Console.WriteLine();
    Console.Write("Origin: ");
    Position origin = Screen.ReadPosition().ToPosition();
    Console.Write("Destination: ");
    Position destination = Screen.ReadPosition().ToPosition();

    match.MoveExec(origin, destination);    


}


