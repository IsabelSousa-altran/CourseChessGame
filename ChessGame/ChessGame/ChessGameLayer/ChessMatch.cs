using System.Collections.Generic;
using BoardLayer;

namespace ChessGameLayer
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int TurnToPlay { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchIsOver { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            TurnToPlay = 1;
            CurrentPlayer = Color.White;
            MatchIsOver = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            
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

            //If had a piece in the target position
            if (capturedPiece != null)
            {
                // Will add this piece to the list of captured pieces
                capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> newListpieces = new HashSet<Piece>();
            // Will go through the list of captured pieces.
            foreach (Piece item in capturedPieces)
            {
                // If the color of that piece is the same as the color listed then put it on a new list. 
                // In the end it returns that new list.
                if (item.Color == color)
                {
                    newListpieces.Add(item);
                }
            }
            return newListpieces;
        }

        public HashSet<Piece> PiecesStillInPlay(Color color)
        {
            HashSet<Piece> newListpieces = new HashSet<Piece>();
            // Will go through the list of all pieces in the board.
            foreach (Piece item in pieces)
            {
                // If the color of that piece is the same as the color listed then put it on a new list. 
                // In the end it returns that new list.
                if (item.Color == color)
                {
                    newListpieces.Add(item);
                }
            }
            // The new list will contain only the pieces of a given color that have not been captured.
            newListpieces.ExceptWith(CapturedPiecesByColor(color));
            return newListpieces;
        }

        // To create new pieces
        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePieceOnBoard(piece, new ChessPosition(column, row).ChessPositionToMatrixPosition());
            // will add the piece to the list
            pieces.Add(piece);
        }
        private void placeAllPieces()
        {
            PutNewPiece('c', 1, new Rook(Color.White, Board));
            PutNewPiece('c', 2, new Rook(Color.White, Board));
            PutNewPiece('d', 2, new Rook(Color.White, Board));
            PutNewPiece('e', 2, new Rook(Color.White, Board));
            PutNewPiece('e', 1, new Rook(Color.White, Board));
            PutNewPiece('d', 1, new King(Color.White, Board));

            PutNewPiece('c', 7, new Rook(Color.Black, Board));
            PutNewPiece('c', 8, new Rook(Color.Black, Board));
            PutNewPiece('d', 7, new Rook(Color.Black, Board));
            PutNewPiece('e', 7, new Rook(Color.Black, Board));
            PutNewPiece('e', 8, new Rook(Color.Black, Board));
            PutNewPiece('d', 8, new King(Color.Black, Board));
        }

    }
}
