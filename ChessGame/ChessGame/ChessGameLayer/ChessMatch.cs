using System;
using BoardLayer;

namespace ChessGameLayer
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int turnToPlay;
        private Color CurrentPlayer;
        public bool MatchIsOver { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turnToPlay = 1;
            CurrentPlayer = Color.White;
            MatchIsOver = false;
            placeAllPieces();
        }

        // The piece will perform a movement from the origin position to the destination position
        public void PerformMovement(PositionBoard originalPosition, PositionBoard positionDestination)
        {
            // Removes the piece from the defined position (origin position),
            Piece piece = Board.RemovePiece(originalPosition);
            // Increase a play.
            piece.IncreaseMovementCount();
            // If there is a piece in the destination position, it will be removed. 
            // It will capture a piece.
            Piece capturedPiece = Board.RemovePiece(positionDestination);
            // Place the piece that was removed from the original position into the destination position
            Board.PlacePieceOnBoard(piece, positionDestination);
        }

        private void placeAllPieces()
        {
            Board.PlacePieceOnBoard(new Rook(Color.White, Board), new ChessPosition('c', 1).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.White, Board), new ChessPosition('c', 2).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.White, Board), new ChessPosition('d', 2).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.White, Board), new ChessPosition('e', 2).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.White, Board), new ChessPosition('e', 1).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new King(Color.White, Board), new ChessPosition('d', 1).ChessPositionToMatrixPosition());

            Board.PlacePieceOnBoard(new Rook(Color.Black, Board), new ChessPosition('c', 7).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.Black, Board), new ChessPosition('c', 8).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.Black, Board), new ChessPosition('d', 7).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.Black, Board), new ChessPosition('e', 7).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new Rook(Color.Black, Board), new ChessPosition('e', 8).ChessPositionToMatrixPosition());
            Board.PlacePieceOnBoard(new King(Color.Black, Board), new ChessPosition('d', 8).ChessPositionToMatrixPosition());
        }

    }
}
