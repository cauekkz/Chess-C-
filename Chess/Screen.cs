using board;
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
                for (int j = 0; j < board.Cols; j++)
                {
                    if (board.GetPiece(i,j) != null)
                    {

                        Console.Write(board.GetPiece(i,j) + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
