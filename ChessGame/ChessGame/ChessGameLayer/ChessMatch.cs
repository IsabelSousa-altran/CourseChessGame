using System;
using BoardLayer;

namespace ChessGameLayer
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int TurnToPlay { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchIsOver { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            TurnToPlay = 1;
            CurrentPlayer = Color.White;
            MatchIsOver = false;
            placeAllPieces();
        }

        
        public void PerformMovement(PositionBoard originalPosition, PositionBoard destinationPosition)
        {
            // Removes the piece from the defined position (origin position),
            Piece piece = Board.RemovePiece(originalPosition);
            // Increase a play.
            piece.IncreaseMovementCount();
            // If there is a piece in the destination position, it will be removed. 
            // It will capture a piece.
            Piece capturedPiece = Board.RemovePiece(destinationPosition);
            // Place the piece that was removed from the original position into the destination position
            Board.PlacePieceOnBoard(piece, destinationPosition);
        }

        // The piece will perform a movement from the origin position to the destination position
        public void MakeAMove(PositionBoard originalPosition, PositionBoard destinationPosition)
        {
            PerformMovement(originalPosition, destinationPosition);
            // change the turn
            TurnToPlay++;
            changesPlayersTurn();
        }

        public void ValidateOriginalPosition(PositionBoard position)
        {
            Board.ValidatePositionException(position);

            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in the chosen original position!");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The piece chosen is not yours!");
            }
            if (!Board.Piece(position).ThereArePossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }
        }

        public void ValidateDestinationPosition(PositionBoard originalPosition, PositionBoard destinationPosition)
        {
            Board.ValidatePositionException(destinationPosition);

            if (!Board.Piece(originalPosition).CanMoveTo(destinationPosition))
            {
                throw new BoardException("Invalid target position");
            }
        }

        //changes the turn to play for the other player
        private void changesPlayersTurn()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
