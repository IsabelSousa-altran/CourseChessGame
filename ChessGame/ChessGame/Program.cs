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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Original: ");
                        // It is always necessary to transform the position provided by the user (chess position) into a matrix position
                        PositionBoard originalPosition = Screen.ReadChessPosition().ChessPositionToMatrixPosition();
                        match.ValidateOriginalPosition(originalPosition);

                        // pick up the required piece in the original position, check which movements are possible and store it in the matrix
                        bool[,] PossiblePositions = match.Board.Piece(originalPosition).PossibleMoviments();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, PossiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        PositionBoard destinationPosition = Screen.ReadChessPosition().ChessPositionToMatrixPosition();
                        match.ValidateDestinationPosition(originalPosition, destinationPosition);
                        match.MakeAMove(originalPosition, destinationPosition);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
