using System;
using BoardLayer;
using ChessGameLayer;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.MatchIsOver)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Source: ");
                    // It is always necessary to transform the position provided by the user (chess position) into a matrix position
                    PositionBoard positionSource = Screen.ReadChessPosition().ChessPositionToMatrixPosition();
                    Console.Write("Destination: ");
                    PositionBoard positionDestination = Screen.ReadChessPosition().ChessPositionToMatrixPosition();

                    match.PerformMovement(positionSource, positionDestination);

                }

                Screen.PrintBoard(match.Board);

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
