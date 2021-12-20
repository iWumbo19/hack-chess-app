using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    internal struct Square
    {
        internal Piece Piece;

        internal Square(Piece piece)
        {
            Piece = new Piece(piece);
        }
    }

    internal sealed class Board
    {
        internal Square[] Squares;

        internal int Score;

        internal bool BlackCheck;
        internal bool BlackMate;
        internal bool WhiteCheck;
        internal bool WhiteMate;
        internal bool StaleMate;

        internal byte FiftyMove;
        internal byte RepeatedMove;

        internal bool BlackCastled;
        internal bool WhiteCastled;

        internal bool EndGamePhase;
        internal MoveContent LastMove;
        internal ChessPieceColor EnPassantColor;  //Color of Player who last moved Pawn two squares
        internal byte EnPassantPosition;          //Square behind Pawn that moved two squares

        internal ChessPieceColor WhoseMove;
        internal int MoveCount;

        internal Board()                         //Creates new Board with Empty Squares
        {
            Squares = new Square[64];

            for (byte i = 0; i < 64; i++)
            {
                Squares[i] = new Square();
            }
            LastMove = new MoveContent();
        }

        internal Board(Board board)              //ReDraws Board based on board passed in
        {
            Squares = new Square[64];

            for (byte i = 0; i < 64; i++)        //Transfers all pieces from old board to new Board
            {
                if (board.Squares[i].Piece != null)
                {
                    Squares[i] = new Square(board.Squares[i].Piece);
                }
            }
            EndGamePhase = board.EndGamePhase;
            FiftyMove = board.FiftyMove;
            RepeatedMove = board.RepeatedMove;
            WhiteCastled = board.WhiteCastled;
            BlackCastled = board.BlackCastled;
            BlackCheck = board.BlackCheck;
            WhiteCheck = board.WhiteCheck;
            StaleMate = board.StaleMate;
            WhiteMate = board.WhiteMate;
            BlackMate = board.BlackMate;
            WhoseMove = board.WhoseMove;
            EnPassantPosition = board.EnPassantPosition;
            EnPassantColor = board.EnPassantColor;
            Score = board.Score;
            LastMove = new MoveContent(board.LastMove);
            MoveCount = board.MoveCount;
        }

        internal Board(int score) : this()       //Constructs board based on score???
        {
            Score = score;
        }

        private Board(Square[] squares)
        {
            Squares = new Square[64];

            for (byte i = 0; i < 64; i++)
            {
                if (squares[i].Piece != null)
                {
                    Squares[i].Piece = new Piece(squares[i].Piece);
                }
            }
        }

        internal Board FastCopy()
        {
            Board clonedBoard = new Board(Squares);

            clonedBoard.EndGamePhase = EndGamePhase;
            clonedBoard.WhoseMove = WhoseMove;
            clonedBoard.MoveCount = MoveCount;
            clonedBoard.FiftyMove = FiftyMove;
            clonedBoard.BlackCastled = BlackCastled;
            clonedBoard.WhiteCastled = WhiteCastled;
            return clonedBoard;
        }

        private static bool PromotePawns(Board board, Piece piece, byte dstPosition,
                  ChessPieceType promoteToPiece)
        {
            if (piece.PieceType == ChessPieceType.Pawn)
            {
                if (dstPosition < 8)
                {
                    board.Squares[dstPosition].Piece.PieceType = promoteToPiece;
                    return true;
                }
                if (dstPosition > 55)
                {
                    board.Squares[dstPosition].Piece.PieceType = promoteToPiece;
                    return true;
                }
            }
            return false;
        }

        private static void RecordEnPassant(ChessPieceColor pcColor, ChessPieceType pcType,
            Board board, byte srcPosition, byte dstPosition)
        {
            if (pcType == ChessPieceType.Pawn)
            {
                board.FiftyMove = 0;

                int difference = srcPosition - dstPosition;
                if (difference == 16 || difference == -16)
                {
                    board.EnPassantPosition = (byte)(dstPosition + (difference / 2));
                    board.EnPassantColor = pcColor;
                }
            }
        }

        private static bool SetEnPassantMove(Board board, byte dstPosition,
            ChessPieceColor pcColor)
        {
            if (board.EnPassantPosition == dstPosition)
            {
                if (pcColor != board.EnPassantColor)
                {
                    int pieceLocationOffset = 8;

                    if (board.EnPassantColor == ChessPieceColor.White)
                    {
                        pieceLocationOffset = -8;
                    }
                    dstPosition = (byte)(dstPosition + pieceLocationOffset);
                    Square sqr = board.Squares[dstPosition];
                    board.LastMove.TakenPiece =
                        new PieceTaken(sqr.Piece.PieceColor, sqr.Piece.PieceType, 
                        sqr.Piece.Moved, dstPosition);

                    board.FiftyMove = 0;
                    return true;
                }
            }
            return false;
        }

        private static void KingCastle(Board board, Piece piece, byte srcPosition, byte dstPosition) ///THIS FUNCTION CAN ONLY SHORT CASTLE!!! NEEDS FIXING
        {
            if (piece.PieceType != ChessPieceType.King)
            {
                return;
            }

            //Lets see if this is a casteling move.
            if (piece.PieceColor == ChessPieceColor.White &&
                   srcPosition == 60)
            {
                //Castle Right_
                if (dstPosition == 62)
                {
                    //Ok we are casteling we need to move the Rook
                    if (board.Squares[63].Piece != null)
                    {
                        board.Squares[61].Piece = board.Squares[63].Piece;
                        board.Squares[63].Piece = null;
                        board.WhiteCastled = true;
                        board.LastMove.MovingPieceSecondary =
                         new PieceMoving(board.Squares[61].Piece.PieceColor,
                             board.Squares[61].Piece.PieceType,
                                  board.Squares[61].Piece.Moved, 63, 61);
                        board.Squares[61].Piece.Moved = true;
                        return;
                    }
                }

                //Castle Left_
                else if (dstPosition == 58)
                {
                    //Ok we are casteling we need to move the Rook_
                    if (board.Squares[56].Piece != null)
                    {
                        board.Squares[59].Piece = board.Squares[56].Piece;
                        board.Squares[56].Piece = null;
                        board.WhiteCastled = true;
                        board.LastMove.MovingPieceSecondary =
                             new PieceMoving(board.Squares[59].Piece.PieceColor,
                                    board.Squares[59].Piece.PieceType,
                                    board.Squares[59].Piece.Moved, 56, 59);
                        board.Squares[59].Piece.Moved = true;
                        return;
                    }
                }
            }

            else if (piece.PieceColor == ChessPieceColor.Black &&
                   srcPosition == 4)
            {
                if (dstPosition == 6)
                {
                    //Ok we are casteling we need to move the Rook_
                    if (board.Squares[7].Piece != null)
                    {
                        board.Squares[5].Piece = board.Squares[7].Piece;
                        board.Squares[7].Piece = null;
                        board.BlackCastled = true;
                        board.LastMove.MovingPieceSecondary =
                            new PieceMoving(board.Squares[5].Piece.PieceColor,
                                     board.Squares[5].Piece.PieceType,
                                     board.Squares[5].Piece.Moved, 7, 5);
                        board.Squares[5].Piece.Moved = true;
                        return;
                    }
                }

                //Castle Left_
                else if (dstPosition == 2)
                {
                    //Ok we are casteling we need to move the Rook_
                    if (board.Squares[0].Piece != null)
                    {
                        board.Squares[3].Piece = board.Squares[0].Piece;
                        board.Squares[0].Piece = null;
                        board.BlackCastled = true;
                        board.LastMove.MovingPieceSecondary =
                           new PieceMoving(board.Squares[3].Piece.PieceColor,
                                    board.Squares[3].Piece.PieceType,
                                    board.Squares[3].Piece.Moved, 0, 3);
                        board.Squares[3].Piece.Moved = true;
                        return;
                    }
                }
            }
            return;
        }

        internal static MoveContent MovePiece(Board board, byte srcPosition, byte dstPosition, ChessPieceType pieceType)
        {
            Piece piece = board.Squares[srcPosition].Piece;

            //Record my last move
            board.LastMove = new MoveContent();
            board.FiftyMove++;

            if (piece.PieceColor == ChessPieceColor.Black) { board.MoveCount++; }

            //EnPassant
            if (board.EnPassantPosition > 0)
            {
                board.LastMove.EnPassantOccured = SetEnPassantMove(board, dstPosition, piece.PieceColor);
            }
            if (!board.LastMove.EnPassantOccured)
            {
                Square sqr = board.Squares[dstPosition];
                if (sqr.Piece != null)
                {
                    board.LastMove.TakenPiece = new PieceTaken(sqr.Piece.PieceColor, sqr.Piece.PieceType,
                        sqr.Piece.Moved, dstPosition);
                    board.FiftyMove = 0;
                }
                else
                {
                    board.LastMove.TakenPiece = new PieceTaken(ChessPieceColor.White, ChessPieceType.None, false, dstPosition);
                }
            }
            board.LastMove.MovingPiecePrimary = new PieceMoving(piece.PieceColor, piece.PieceType, piece.Moved, srcPosition, dstPosition);
            board.Squares[srcPosition].Piece = null;
            piece.Moved = true;
            piece.Selected = false;
            board.Squares[dstPosition].Piece = piece;
            board.EnPassantPosition = 0;

            if (piece.PieceType == ChessPieceType.Pawn)
            {
                board.FiftyMove = 0;
                RecordEnPassant(piece.PieceColor, piece.PieceType, board, srcPosition, dstPosition);
            }
            board.WhoseMove = board.WhoseMove == ChessPieceColor.White
                ? ChessPieceColor.Black //if board.WhoseMove is white
                : ChessPieceColor.White; //if board.WhoseMove is black
            KingCastle(board, piece, srcPosition, dstPosition);
            if (PromotePawns(board, piece, dstPosition, pieceType))
            {
                board.LastMove.PawnPromoted = true;
            }
            else { board.LastMove.PawnPromoted = true; }
            if (board.FiftyMove >= 50) { board.StaleMate = true; }
            return board.LastMove;
        }
    }
}
