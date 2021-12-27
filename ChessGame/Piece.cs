using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public enum ChessPieceColor
    {
        White,
        Black
    }

    public enum ChessPieceType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn,
        None
    }

    internal sealed class Piece
    {
        internal ChessPieceColor PieceColor;
        internal ChessPieceType PieceType;

        internal short PieceValue;
        internal short AttackedValue;
        internal short DefendedValue;
        internal short PieceActionValue;
        internal bool Selected;
        internal int LastValidMoveCount;

        internal bool Moved;

        internal List<byte> ValidMoves;

        internal Piece(Piece piece)
        {
            PieceColor = piece.PieceColor;
            PieceType = piece.PieceType;
            Moved = piece.Moved;
            PieceValue = piece.PieceValue;

            if (piece.ValidMoves != null)
                LastValidMoveCount = piece.ValidMoves.Count;
        }

        internal Piece(ChessPieceType chessPiece, ChessPieceColor chessPieceColor)
        {
            PieceType = chessPiece;
            PieceColor = chessPieceColor;

            ValidMoves = new List<byte>();
            PieceValue = CalculatePieceValue(PieceType);
        }


        private static short CalculatePieceValue(ChessPieceType pieceType)
        {
            return pieceType switch
            {
                ChessPieceType.King => 32767,
                ChessPieceType.Queen => 975,
                ChessPieceType.Rook => 500,
                ChessPieceType.Bishop => 325,
                ChessPieceType.Knight => 320,
                ChessPieceType.Pawn => 100,
                _ => 0,
            };
        }

        private static short CalculatePieceActionValue(ChessPieceType pieceType)
        {
            return pieceType switch
            {
                ChessPieceType.King => 1,
                ChessPieceType.Queen => 1,
                ChessPieceType.Rook => 2,
                ChessPieceType.Bishop => 3,
                ChessPieceType.Knight => 3,
                ChessPieceType.Pawn => 6,
                _ => 0,
            };
        }
    }
}
