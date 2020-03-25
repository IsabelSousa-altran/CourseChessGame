using System;
using BoardLayer;
using ChessGameLayer;
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

                for (int j = 0; j < board.Columns; j++)
                {
                    // If there is no piece in row i column j
                    PrintPieceOnTheBoard(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor BackgroundChanged = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                //It will print on the screen the numbers corresponding to each line (1-8)
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i,j])
                    {
                        Console.BackgroundColor = BackgroundChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackground;
                    }
                    // If there is no piece in row i column j
                    PrintPieceOnTheBoard(board.Piece(i, j));
                    Console.BackgroundColor = OriginalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = OriginalBackground;
        }

        // Will read the position provided by the player and return it 
        public static ChessPosition ReadChessPosition()
        {
            string userChessPosition = Console.ReadLine();
            char columnChar = userChessPosition[0];
            int rowInt = int.Parse(userChessPosition[1] + "");
            return new ChessPosition(columnChar, rowInt);
        }

        // It will change the color of the piece, in case the piece is black
        public static void PrintPieceOnTheBoard(Piece piece)
        {
            // If don't have a piece
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
