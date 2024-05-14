using board;
using chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch m)
        {
            PrintBoard(m.board);
            Console.WriteLine();
            PrintCapturedPieces(m);
            Console.WriteLine();
            if (!m.Finished)
            {
                Console.WriteLine("Turn: " + m.turn);
                Console.WriteLine("Waiting for move: " + m.player);
                if (m.check)
                    Console.WriteLine("CHECK!!");
            }
            else
            {
                Console.WriteLine("CHECKMATE!!");
                Console.WriteLine("Winner: " + m.player);
            }

            Console.WriteLine();


        }
        public static void PrintCapturedPieces(ChessMatch m)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(m.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(m.CapturedPieces(Color.Black));
            Console.ResetColor();
        }
        public static void PrintSet(HashSet<Piece> h)
        {
            Console.Write("[");
            foreach (Piece x in h)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ResetColor();

                for (int j = 0; j < board.Cols; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }

                    PrintPiece(board.GetPiece(i, j));
                    Console.ResetColor();

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ResetColor();
        }

        public static void PrintBoard(Board board, bool[,] mtx)
        {
            ConsoleColor consoleAltColor = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ResetColor();

                for (int j = 0; j < board.Cols; j++)
                {

                    if (i % 2 == 0 && !mtx[i,j])
                    {
                        if (j % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    else if (i % 2 != 0 && !mtx[i, j])
                    {
                        if (j % 2 != 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = consoleAltColor;
                    }
                    
                    PrintPiece(board.GetPiece(i, j));
                    Console.ResetColor();

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ResetColor();

        }
        public static void PrintPiece(Piece piece)
        {

            if (piece == null)
            {

                Console.Write("  ");
            }
            else
            {

                if (piece.color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(piece);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(piece);
                }
                Console.Write(" ");
            }


        }

        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            return new ChessPosition(s[0], int.Parse(s[1] + ""));

        }

    }
}
