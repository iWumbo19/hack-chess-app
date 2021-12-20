using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLibrary;

namespace ChessBoardGUI
{
    internal static class CurrentBoard
    {
        internal static Square[] Squares;

        internal static int Score;

        internal static bool BlackCheck;
        internal static bool BlackMate;
        internal static bool WhiteCheck;
        internal static bool WhiteMate;
        internal static bool StaleMate;

        internal static byte FiftyMove;
        internal static byte RepeatedMove;

        internal static bool BlackCastled;
        internal static bool WhiteCastled;

        internal static bool EndGamePhase;
        internal static ChessPieceColor EnPassantColor;  //Color of Player who last moved Pawn two squares
        internal static byte EnPassantPosition;          //Square behind Pawn that moved two squares

        internal static ChessPieceColor WhoseMove;
        internal static int MoveCount;

        internal static void SetupBoard()
        {
            //Creates New Array filled with empty Squares
            Squares = new Square[64];
            for (byte i = 0; i < 64; i++)
            {
                if (Squares[i].Piece != null)
                {
                    Squares[i].Piece = new Piece(Squares[i].Piece);
                }
            }
            PlaceStartingPieces();
        }

        static private void PlaceStartingPieces()
        {
            Squares[0].Piece = new Piece(ChessPieceType.Rook, ChessPieceColor.Black);
            Squares[1].Piece = new Piece(ChessPieceType.Knight, ChessPieceColor.Black);
            Squares[2].Piece = new Piece(ChessPieceType.Bishop, ChessPieceColor.Black);
            Squares[3].Piece = new Piece(ChessPieceType.Queen, ChessPieceColor.Black);
            Squares[4].Piece = new Piece(ChessPieceType.King, ChessPieceColor.Black);
            Squares[5].Piece = new Piece(ChessPieceType.Bishop, ChessPieceColor.Black);
            Squares[6].Piece = new Piece(ChessPieceType.Knight, ChessPieceColor.Black);
            Squares[7].Piece = new Piece(ChessPieceType.Rook, ChessPieceColor.Black);

            Squares[8].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[9].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[10].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[11].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[12].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[13].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[14].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
            Squares[15].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);

            Squares[48].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[49].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[50].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[51].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[52].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[53].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[54].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
            Squares[55].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);

            Squares[56].Piece = new Piece(ChessPieceType.Rook, ChessPieceColor.White);
            Squares[57].Piece = new Piece(ChessPieceType.Knight, ChessPieceColor.White);
            Squares[58].Piece = new Piece(ChessPieceType.Bishop, ChessPieceColor.White);
            Squares[59].Piece = new Piece(ChessPieceType.Queen, ChessPieceColor.White);
            Squares[60].Piece = new Piece(ChessPieceType.King, ChessPieceColor.White);
            Squares[61].Piece = new Piece(ChessPieceType.Bishop, ChessPieceColor.White);
            Squares[62].Piece = new Piece(ChessPieceType.Knight, ChessPieceColor.White);
            Squares[63].Piece = new Piece(ChessPieceType.Rook, ChessPieceColor.White);
        }
    }


    


}
