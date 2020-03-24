using System;
using BoardLayer;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);


            //board.PlacePieceOnBoard( , new PositionBoard(0, 0));
            //board.PlacePieceOnBoard( , new PositionBoard(1, 3));
            //board.PlacePieceOnBoard( , new PositionBoard(2, 4));


            Screen.PrintBoard(board);
            
            Console.ReadLine();
        }
    }
}
