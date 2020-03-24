using System;
using BoardLayer;
using ChessGameLayer;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessPosition position = new ChessPosition('c', 7);

            Console.WriteLine(position);

            Console.WriteLine(position.ChessPositionToMatrixPosition());

            
            //try
            //{
            //    Board board = new Board(8, 8);


            //    board.PlacePieceOnBoard(new Rook(Color.Black, board), new PositionBoard(0, 0));
            //    board.PlacePieceOnBoard(new Rook(Color.Black, board), new PositionBoard(1, 3));
            //    board.PlacePieceOnBoard(new King(Color.Black, board), new PositionBoard(0, 2));


            //    Screen.PrintBoard(board);

            //    Console.ReadLine();
            //}
            //catch (BoardException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
