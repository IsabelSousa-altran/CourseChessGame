using System;
using BoardLayer;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionBoard position = new PositionBoard(3, 4);
            Console.WriteLine("Posição: " + position);

            Console.WriteLine();
        }
    }
}
