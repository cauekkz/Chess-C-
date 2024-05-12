using board;
using chess;
using Chess;

ChessMatch match = new ChessMatch();
Screen.PrintBoard(match.board);
while (!match.Finished)
{
    try
    {
        Console.Clear();
        Screen.PrintMatch(match);
        Console.Write("Origin: ");
        Position origin = Screen.ReadPosition().ToPosition();
        match.ValidOriginPosition(origin);
        Console.Clear();
        bool[,] possiblePositions = match.board.GetPiece(origin).PossibleMovements();
        Screen.PrintBoard(match.board, possiblePositions);


        Console.Write("Destination: ");
        Position destination = Screen.ReadPosition().ToPosition();
        match.ValidDestinationPosition(origin,destination);


        match.MakePlay(origin, destination);

    }catch(BoardException e)
    {
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }

}


