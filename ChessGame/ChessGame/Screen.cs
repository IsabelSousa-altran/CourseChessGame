using System;
using BoardLayer;
using System.Text;

namespace ChessGame
{
    class Screen
    {
        // Will print the board on the screen
        public static void PrintBoard (Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columms; j++)
                {
                    // If there is no piece in row i column j
                    if (board.Piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    // If it exists then place the piece
                    {
                        Console.Write(board.Piece(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
