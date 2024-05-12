using board;
using chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Cols; j++)
                {


                    PrintPiece(board.GetPiece(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(Board board,bool[,] mtx)
        {
            ConsoleColor consoleAltColor = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Cols; j++)
                {

                    if (mtx[i, j])
                    {
                        Console.BackgroundColor = consoleAltColor;
                    }
                   
                    PrintPiece(board.GetPiece(i, j));
                    Console.ResetColor();

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ResetColor();
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
