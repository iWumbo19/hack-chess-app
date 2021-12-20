using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public sealed class Engine
    {
        internal Board ChessBoard;

        internal Stack<MoveContent> MoveHistory { get; }

        internal Board PreviousChessBoard;

        public ChessPieceColor WhoseMove
        {
            get { return ChessBoard.WhoseMove; }
            set { ChessBoard.WhoseMove = value; }
        }

        public Engine()
        {
            ChessBoard = new Board();
            MoveHistory = new Stack<MoveContent>();

            //RegisterStartingBoard();
            PieceMoves.InitiateChessPieceMotion();
            PieceValidMoves.GenerateValidMoves(ChessBoard);
        }

        private void RegisterPiece(byte boardColumn, byte boardRow, Piece piece)
        {
            byte position = (byte)(boardColumn + (boardRow * 8));

            ChessBoard.Squares[position].Piece = piece;
        }

        public bool MovePiece(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
        {
            byte srcPosition = (byte)(sourceColumn + (sourceRow * 8));
            byte dstPosition = (byte)(destinationColumn + (destinationRow * 8));

            Piece Piece = ChessBoard.Squares[srcPosition].Piece;
            PreviousChessBoard = new Board(ChessBoard);

            Board.MovePiece(ChessBoard, srcPosition, dstPosition, ChessPieceType.Queen);
            PieceValidMoves.GenerateValidMoves(ChessBoard);

            if (Piece.PieceColor == ChessPieceColor.White)
            {
                if (ChessBoard.WhiteCheck)
                {
                    ChessBoard = new Board(PreviousChessBoard);
                    PieceValidMoves.GenerateValidMoves(ChessBoard);
                    return false;
                }
            }
            else if (Piece.PieceColor == ChessPieceColor.Black)
            {
                if (ChessBoard.BlackCheck)
                {
                    ChessBoard = new Board(PreviousChessBoard);
                    PieceValidMoves.GenerateValidMoves(ChessBoard);
                    return false;
                }
            }
            MoveHistory.Push(ChessBoard.LastMove);
            return true;
        }

    }
}
