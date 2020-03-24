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
                //It will print on the screen the numbers corresponding to each line (1-8)
                Console.Write(8 - i + " ");

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
                        PrintPieceOfDifferentColor(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        // It will change the color of the piece, in case the piece is black
        public static void PrintPieceOfDifferentColor(Piece piece)
        {
            // If the piece is white, print the piece with the normal color of the console.
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                // If the piece is black prints the piece in blue
                ConsoleColor newPieceColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(piece);
                Console.ForegroundColor = newPieceColor;
            }
        }
    }
}
