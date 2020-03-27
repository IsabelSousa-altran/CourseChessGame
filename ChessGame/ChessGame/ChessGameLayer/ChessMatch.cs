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
        private HashSet<Piece> setPieces;
        private HashSet<Piece> setCapturedPieces;
        public bool MatchInCheck { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            TurnToPlay = 1;
            CurrentPlayer = Color.White;
            MatchIsOver = false;
            MatchInCheck = false;
            setPieces = new HashSet<Piece>();
            setCapturedPieces = new HashSet<Piece>();
            
            placeAllPieces();
        }

        
        public Piece PerformMovement(PositionBoard originalPosition, PositionBoard destinationPosition)
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
                setCapturedPieces.Add(capturedPiece);
            }

            //SPECIAL MOVE : small castling
            if (piece is King && destinationPosition.Column == originalPosition.Column + 2)
            {
                PositionBoard originalPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column + 3);
                PositionBoard destinationPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column + 1);
                Piece rook = Board.RemovePiece(originalPositionRook);
                rook.IncreaseMovementCount();
                Board.PlacePieceOnBoard(rook, destinationPositionRook);
            }

            //SPECIAL MOVE : big castling
            if (piece is King && destinationPosition.Column == originalPosition.Column - 2)
            {
                PositionBoard originalPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column - 4);
                PositionBoard destinationPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column - 1);
                Piece rook = Board.RemovePiece(originalPositionRook);
                rook.IncreaseMovementCount();
                Board.PlacePieceOnBoard(rook, destinationPositionRook);
            }
            return capturedPiece;
        }

        public void UndoMoves(PositionBoard originalPosition, PositionBoard destinationPosition, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destinationPosition);
            piece.DecreaseMovementCount();

            // There was a piece that was captured
            if (capturedPiece != null)
            {
                // I go to the board and place the captured piece back at the destination
                Board.PlacePieceOnBoard(capturedPiece, destinationPosition);
                // I go to the set of captured pieces and remove that captured piece
                setCapturedPieces.Remove(capturedPiece);
            }
            // Put the piece back in the original position.
            Board.PlacePieceOnBoard(piece, originalPosition);

            //SPECIAL MOVE : small castling
            if (piece is King && destinationPosition.Column == originalPosition.Column + 2)
            {
                PositionBoard originalPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column + 3);
                PositionBoard destinationPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column + 1);
                Piece rook = Board.RemovePiece(destinationPositionRook);
                rook.DecreaseMovementCount();
                Board.PlacePieceOnBoard(rook, originalPositionRook);
            }

            //SPECIAL MOVE : Big castling
            if (piece is King && destinationPosition.Column == originalPosition.Column - 2)
            {
                PositionBoard originalPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column -4);
                PositionBoard destinationPositionRook = new PositionBoard(originalPosition.Row, originalPosition.Column - 1);
                Piece rook = Board.RemovePiece(destinationPositionRook);
                rook.DecreaseMovementCount();
                Board.PlacePieceOnBoard(rook, originalPositionRook);
            }
        }

        // The piece will perform a movement from the origin position to the destination position.
        public void MakeAMove(PositionBoard originalPosition, PositionBoard destinationPosition)
        {
           Piece capturedPiece = PerformMovement(originalPosition, destinationPosition);

            // The opponent can be in check with my move, but I can't.
            if (KingIsInCheck(CurrentPlayer))
            {
                UndoMoves(originalPosition, destinationPosition, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (KingIsInCheck(colorOpponent(CurrentPlayer)))
            {
                MatchInCheck = true;
            }
            else
            {
                MatchInCheck = false;
            }

            // If the method in which the checkmate is being tested returns true then the game is ended
            if (TestCheckmate(colorOpponent(CurrentPlayer)))
            {
                MatchIsOver = true;
            }
            else
            // Else continues with the next player's move
            {
                // change the turn
                TurnToPlay++;
                changesPlayersTurn();
            }
            
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
            foreach (Piece item in setCapturedPieces)
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
            foreach (Piece item in setPieces)
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

        // Check the opponent's color
        private Color colorOpponent (Color cor)
        {
            if (cor == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        // Will return the king of a given color.
        private Piece king (Color color)
        {
            foreach  (Piece item in PiecesStillInPlay(color))
            {
                // To test whether a variable of the superclass type is an instance of some subclass, 
                // it is necessary to use the "is".
                if (item is King)
                {
                    return item;
                }
            }
            // If the cycle "for" ends and there is no king (it is not supposed to happen) it will return null.
            return null;
        }

        // It will check if the king of a given color is in check.
        public bool KingIsInCheck(Color color)
        {
            Piece kingPiece = king(color);
            if (kingPiece == null)
            {
                throw new BoardException($"There is no {color} king on the board!");
            }

            // For each opposing piece, I will take the possible movements of each piece
            foreach (Piece item in PiecesStillInPlay(colorOpponent(color)))
            {
                bool[,] possibleMovesMatrix = item.PossibleMoviments();
                // If there is a possible movement (true) in the position where the king is, 
                // that means that piece can move to the king.
                if (possibleMovesMatrix[kingPiece.PositionBoard.Row, kingPiece.PositionBoard.Column])
                {
                    // Tt means that the king is in check
                    return true;
                }
            }
            // if you go through all the pieces and in the end there is no true it means that the king is not in check
            return false;
        }

        // Check on all pieces of the same color as the king if there  is one that moves the check from the king. 
        // If we run out of possibilities and it is not possible to move any, we conclude that the king is in checkmate.
        // And the game is over.
        public bool TestCheckmate(Color color)
        {
            // If the king of that color is not in check, then there is no need to check if he is in checkmate
            if (!KingIsInCheck(color))
            {
                return false;
            }
            foreach (Piece item in PiecesStillInPlay(color))
            {
                bool[,] possibleMovesMatrix = item.PossibleMoviments();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (possibleMovesMatrix[i,j])
                        {
                            PositionBoard originalPosition = item.PositionBoard;
                            PositionBoard destination = new PositionBoard(i, j);
                            Piece capturedPiece = PerformMovement(originalPosition, destination);
                            bool checkTest = KingIsInCheck(color);
                            UndoMoves(originalPosition, destination, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            return true;
        }

        // To create new pieces
        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePieceOnBoard(piece, new ChessPosition(column, row).ChessPositionToMatrixPosition());
            // will add the piece to the list
            setPieces.Add(piece);
        }
        private void placeAllPieces()
        {
            PutNewPiece('a', 1, new Rook(Color.White, Board));
            PutNewPiece('b', 1, new Knight(Color.White, Board));
            PutNewPiece('c', 1, new Bishop(Color.White, Board));
            PutNewPiece('d', 1, new Queen(Color.White, Board));
            PutNewPiece('e', 1, new King(Color.White, Board, this));
            PutNewPiece('f', 1, new Bishop(Color.White, Board));
            PutNewPiece('g', 1, new Knight(Color.White, Board));
            PutNewPiece('h', 1, new Rook(Color.White, Board));
            PutNewPiece('a', 2, new Pown(Color.White, Board));
            PutNewPiece('b', 2, new Pown(Color.White, Board));
            PutNewPiece('c', 2, new Pown(Color.White, Board));
            PutNewPiece('d', 2, new Pown(Color.White, Board));
            PutNewPiece('e', 2, new Pown(Color.White, Board));
            PutNewPiece('f', 2, new Pown(Color.White, Board));
            PutNewPiece('g', 2, new Pown(Color.White, Board));
            PutNewPiece('h', 2, new Pown(Color.White, Board));


            PutNewPiece('a', 8, new Rook(Color.Black, Board));
            PutNewPiece('b', 8, new Knight(Color.Black, Board));
            PutNewPiece('c', 8, new Bishop(Color.Black, Board));
            PutNewPiece('d', 8, new Queen(Color.Black, Board));
            PutNewPiece('e', 8, new King(Color.Black, Board, this));
            PutNewPiece('f', 8, new Bishop(Color.Black, Board));
            PutNewPiece('g', 8, new Knight(Color.Black, Board));
            PutNewPiece('h', 8, new Rook(Color.Black, Board));
            PutNewPiece('a', 7, new Pown(Color.Black, Board));
            PutNewPiece('b', 7, new Pown(Color.Black, Board));
            PutNewPiece('c', 7, new Pown(Color.Black, Board));
            PutNewPiece('d', 7, new Pown(Color.Black, Board));
            PutNewPiece('e', 7, new Pown(Color.Black, Board));
            PutNewPiece('f', 7, new Pown(Color.Black, Board));
            PutNewPiece('g', 7, new Pown(Color.Black, Board));
            PutNewPiece('h', 7, new Pown(Color.Black, Board));
        }
    }
}
