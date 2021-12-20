using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    internal struct PieceMoveSet
    {
        internal readonly List<byte> Moves;

        internal PieceMoveSet(List<byte> moves)
        {
            Moves = moves;
        }
    }

    internal struct MoveArrays
    {
        internal static PieceMoveSet[] BishopMoves1;
        internal static byte[] BishopTotalMoves1;
        internal static PieceMoveSet[] BishopMoves2;
        internal static byte[] BishopTotalMoves2;
        internal static PieceMoveSet[] BishopMoves3;
        internal static byte[] BishopTotalMoves3;
        internal static PieceMoveSet[] BishopMoves4;
        internal static byte[] BishopTotalMoves4;

        internal static PieceMoveSet[] BlackPawnMoves;
        internal static byte[] BlackPawnTotalMoves;
        internal static PieceMoveSet[] WhitePawnMoves;
        internal static byte[] WhitePawnTotalMoves;

        internal static PieceMoveSet[] KnightMoves;
        internal static byte[] KnightTotalMoves;

        internal static PieceMoveSet[] QueenMoves1;
        internal static byte[] QueenTotalMoves1;
        internal static PieceMoveSet[] QueenMoves2;
        internal static byte[] QueenTotalMoves2;
        internal static PieceMoveSet[] QueenMoves3;
        internal static byte[] QueenTotalMoves3;
        internal static PieceMoveSet[] QueenMoves4;
        internal static byte[] QueenTotalMoves4;
        internal static PieceMoveSet[] QueenMoves5;
        internal static byte[] QueenTotalMoves5;
        internal static PieceMoveSet[] QueenMoves6;
        internal static byte[] QueenTotalMoves6;
        internal static PieceMoveSet[] QueenMoves7;
        internal static byte[] QueenTotalMoves7;
        internal static PieceMoveSet[] QueenMoves8;
        internal static byte[] QueenTotalMoves8;

        internal static PieceMoveSet[] RookMoves1;
        internal static byte[] RookTotalMoves1;
        internal static PieceMoveSet[] RookMoves2;
        internal static byte[] RookTotalMoves2;
        internal static PieceMoveSet[] RookMoves3;
        internal static byte[] RookTotalMoves3;
        internal static PieceMoveSet[] RookMoves4;
        internal static byte[] RookTotalMoves4;

        internal static PieceMoveSet[] KingMoves;
        internal static byte[] KingTotalMoves;

    }

    internal static class PieceMoves
    {
        private static void SetMovesBlackPawn()
        {
            for (byte index = 8; index <= 55; index++)
            {
                var moveset = new PieceMoveSet(new List<byte>());

                byte x = (byte)(index % 8);
                byte y = (byte)((index / 8));

                //Diagonal Kill
                if (y < 7 && x < 7)
                {
                    moveset.Moves.Add((byte)(index + 8 + 1));
                    MoveArrays.BlackPawnTotalMoves[index]++;
                }
                if (x > 0 && y < 7)
                {
                    moveset.Moves.Add((byte)(index + 8 - 1));
                    MoveArrays.BlackPawnTotalMoves[index]++;
                }

                //One Forward
                moveset.Moves.Add((byte)(index + 8));
                MoveArrays.BlackPawnTotalMoves[index]++;

                //Starting Position we can jump 2_
                if (y == 1)
                {
                    moveset.Moves.Add((byte)(index + 16));
                    MoveArrays.BlackPawnTotalMoves[index]++;
                }
                MoveArrays.BlackPawnMoves[index] = moveset;
            }
        }

        private static void SetMovesWhitePawn()
        {
            for (byte index = 8; index <= 55; index++)
            {
                byte x = (byte)(index % 8);
                byte y = (byte)((index / 8));
                var moveset = new PieceMoveSet(new List<byte>());


                //Diagonal Kill_
                if (x < 7 && y > 0)
                {
                    moveset.Moves.Add((byte)(index - 8 + 1));
                    MoveArrays.WhitePawnTotalMoves[index]++;
                }
                if (x > 0 && y > 0)
                {
                    moveset.Moves.Add((byte)(index - 8 - 1));
                    MoveArrays.WhitePawnTotalMoves[index]++;
                }
                //One Forward_ 
                moveset.Moves.Add((byte)(index - 8));
                MoveArrays.WhitePawnTotalMoves[index]++;
                //Starting Position we can jump 2_
                if (y == 6)
                {
                    moveset.Moves.Add((byte)(index - 16));
                    MoveArrays.WhitePawnTotalMoves[index]++;
                }
                MoveArrays.WhitePawnMoves[index] = moveset;
            }
        }

        private static void SetMovesKnight()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));
                    var moveset = new PieceMoveSet(new List<byte>());

                    byte move;
                    if (y < 6 && x > 0)
                    {
                        move = Position((byte)(y + 2), (byte)(x - 1));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y > 1 && x < 7)
                    {
                        move = Position((byte)(y - 2), (byte)(x + 1));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y > 1 && x > 0)
                    {
                        move = Position((byte)(y - 2), (byte)(x - 1));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y < 6 && x < 7)
                    {
                        move = Position((byte)(y + 2), (byte)(x + 1));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y > 0 && x < 6)
                    {
                        move = Position((byte)(y - 1), (byte)(x + 2));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y < 7 && x > 1)
                    {
                        move = Position((byte)(y + 1), (byte)(x - 2));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y > 0 && x > 1)
                    {
                        move = Position((byte)(y - 1), (byte)(x - 2));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    if (y < 7 && x < 6)
                    {
                        move = Position((byte)(y + 1), (byte)(x + 2));
                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    MoveArrays.KnightMoves[index] = moveset;
                }
            }
        }

        private static void SetMovesBishop()
        {
            for (byte y = 0; y < 8; y++)      //For Every Row
            {
                for (byte x = 0; x < 8; x++)  //And Every Column (Every Position on board from 0-63)
                {
                    byte index = (byte)(y + (x * 8));
                    var moveset = new PieceMoveSet(new List<byte>());   //Create New PieceMoveSet List
                    byte move;                                          //Indicates Current Position Being Checked   
                    byte row = x;                                       //Translates x to row for iteration
                    byte col = y;                                       //Translates y to column for iteration
                    while (row < 7 && col < 7)                          //While we havn't left the Bottom Right of Board
                    {
                        row++;                                          //Increase the row
                        col++;                                          //Increase the column
                        move = Position(col, row);                      //Translate col,row to Array Position
                        moveset.Moves.Add(move);                        //Add that position to the moveset List
                        MoveArrays.BishopTotalMoves1[index]++;          //Increase the associated TotalMovesList
                    }
                    MoveArrays.BishopMoves1[index] = moveset;           //Add created list to MoveArray

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row < 7 && col > 0)
                    {
                        row++;
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves2[index]++;
                    }
                    MoveArrays.BishopMoves2[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row > 0 && col < 7)
                    {
                        row--;
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves3[index]++;
                    }
                    MoveArrays.BishopMoves3[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row > 0 && col > 0)
                    {
                        row--;
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves4[index]++;
                    }
                    MoveArrays.BishopMoves4[index] = moveset;
                }
            }
        }

        private static void SetMovesRook()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));
                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;
                    byte row = x;
                    byte col = y;
                    while (row < 7)
                    {
                        row++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves1[index]++;
                    }

                    MoveArrays.RookMoves1[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row > 0)
                    {
                        row--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves2[index]++;
                    }

                    MoveArrays.RookMoves2[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (col > 0)
                    {
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves3[index]++;
                    }

                    MoveArrays.RookMoves3[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (col < 7)
                    {
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves4[index]++;
                    }
                    MoveArrays.RookMoves4[index] = moveset;
                }
            }
        }

        private static void SetMovesQueen()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));
                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;
                    byte row = x;
                    byte col = y;
                    while (row < 7)
                    {
                        row++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves1[index]++;
                    }
                    MoveArrays.QueenMoves1[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row > 0)
                    {
                        row--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves2[index]++;
                    }
                    MoveArrays.QueenMoves2[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (col > 0)
                    {
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves3[index]++;
                    }
                    MoveArrays.QueenMoves3[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (col < 7)
                    {
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves4[index]++;
                    }
                    MoveArrays.QueenMoves4[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row < 7 && col < 7)
                    {
                        row++;
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves5[index]++;     
                    }
                    MoveArrays.QueenMoves5[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row < 7 && col > 0)
                    {
                        row++;
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves6[index]++;
                    }
                    MoveArrays.QueenMoves6[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row > 0 && col < 7)
                    {
                        row--;
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves7[index]++;
                    }
                    MoveArrays.QueenMoves7[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;
                    while (row > 0 && col > 0)
                    {
                        row--;
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves8[index]++;
                    }
                    MoveArrays.QueenMoves8[index] = moveset;
                }
            }
        }

        private static void SetMovesKing()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));
                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;
                    byte row = x;
                    byte col = y;
                    if (row < 7)
                    {
                        row++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (row > 0)
                    {
                        row--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (col > 0)
                    {
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (col < 7)
                    {
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (row < 7 && col < 7)
                    {
                        row++;
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (row < 7 && col > 0)
                    {
                        row++;
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (row > 0 && col < 7)
                    {
                        row--;
                        col++;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    row = x;
                    col = y;
                    if (row > 0 && col > 0)
                    {
                        row--;
                        col--;
                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }
                    MoveArrays.KingMoves[index] = moveset;
                }
            }
        }


        internal static void InitiateChessPieceMotion()
        {
            MoveArrays.WhitePawnMoves = new PieceMoveSet[64];
            MoveArrays.WhitePawnTotalMoves = new byte[64];


            MoveArrays.BlackPawnMoves = new PieceMoveSet[64];
            MoveArrays.BlackPawnTotalMoves = new byte[64];
            MoveArrays.KnightMoves = new PieceMoveSet[64];
            MoveArrays.KnightTotalMoves = new byte[64];
            MoveArrays.BishopMoves1 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves1 = new byte[64];
            MoveArrays.BishopMoves2 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves2 = new byte[64];
            MoveArrays.BishopMoves3 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves3 = new byte[64];
            MoveArrays.BishopMoves4 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves4 = new byte[64];
            MoveArrays.RookMoves1 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves1 = new byte[64];
            MoveArrays.RookMoves2 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves2 = new byte[64];
            MoveArrays.RookMoves3 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves3 = new byte[64];
            MoveArrays.RookMoves4 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves4 = new byte[64];
            MoveArrays.QueenMoves1 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves1 = new byte[64];
            MoveArrays.QueenMoves2 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves2 = new byte[64];
            MoveArrays.QueenMoves3 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves3 = new byte[64];
            MoveArrays.QueenMoves4 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves4 = new byte[64];
            MoveArrays.QueenMoves5 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves5 = new byte[64];
            MoveArrays.QueenMoves6 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves6 = new byte[64];
            MoveArrays.QueenMoves7 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves7 = new byte[64];
            MoveArrays.QueenMoves8 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves8 = new byte[64];
            MoveArrays.KingMoves = new PieceMoveSet[64];
            MoveArrays.KingTotalMoves = new byte[64];

            SetMovesWhitePawn();
            SetMovesBlackPawn();
            SetMovesKnight();
            SetMovesBishop();
            SetMovesRook();
            SetMovesQueen();
            SetMovesKing();
        }

        private static byte Position(byte col, byte row)
        {
            return (byte)(col + (row * 8));
        }
    }

    internal static class PieceValidMoves
    {
        internal static bool[] BlackAttackBoard;
        internal static bool[] WhiteAttackBoard;

        private static byte BlackKingPosition;
        private static byte WhiteKingPosition;

        private static bool AnalyzeMove(Board board, byte dstPos, Piece pcMoving)
        {
            //If I am not a pawn everywhere I move I can attack
            if (pcMoving.PieceColor == ChessPieceColor.White)
            {
                WhiteAttackBoard[dstPos] = true;
            }
            else
            {
                BlackAttackBoard[dstPos] = true;
            }


            //If there no piece there I can potentialy kill just add the move and exit_
            if (board.Squares[dstPos].Piece == null)
            {
                pcMoving.ValidMoves.Push(dstPos);
                return true;
            }

            Piece pcAttacked = board.Squares[dstPos].Piece;
            //if that piece is a different color_
            if (pcAttacked.PieceColor != pcMoving.PieceColor)
            {
                pcAttacked.AttackedValue += pcMoving.PieceActionValue;
                //If this is a king set it in check 
                if (pcAttacked.PieceType == ChessPieceType.King)
                {
                    if (pcAttacked.PieceColor == ChessPieceColor.Black)
                    {
                        board.BlackCheck = true;
                    }
                    else
                    {
                        board.WhiteCheck = true;
                    }
                }
                else
                {
                    //Add this as a valid move_
                    pcMoving.ValidMoves.Push(dstPos);
                }


                //We don't continue movement past this piece_
                return false;
            }
            //Same Color I am defending_
            pcAttacked.DefendedValue += pcMoving.PieceActionValue;
            //Since this piece is of my kind I can't move there_
            return false;
        }

        private static void CheckValidMovesPawn(List<byte> moves, Piece pcMoving,
            byte srcPosition, Board board, byte count)
        {
            for (byte i = 0; i < count; i++)
            {
                byte dstPos = moves[i];

                if (dstPos % 8 != srcPosition % 8)
                {
                    //If there is a piece there I can potentialy kill_
                    AnalyzeMovePawn(board, dstPos, pcMoving);
                    if (pcMoving.PieceColor == ChessPieceColor.White)
                    {
                        WhiteAttackBoard[dstPos] = true;
                    }
                    else
                    {
                        BlackAttackBoard[dstPos] = true;
                    }
                }
                // if there is something if front pawns can't move there_
                else if (board.Squares[dstPos].Piece != null)
                {
                    return;
                }
                //if there is nothing in front of me (blocked == false)_
                else
                {
                    pcMoving.ValidMoves.Push(dstPos);
                }
            }
        }

        private static void AnalyzeMovePawn(Board board, byte dstPos, Piece pcMoving)
        {
            //Because Pawns only kill diagonaly we handle the En Passant scenario specialy
            if (board.EnPassantPosition > 0)
            {
                if (pcMoving.PieceColor != board.EnPassantColor)
                {
                    if (board.EnPassantPosition == dstPos)
                    {
                        //We have an En Passant Possible
                        pcMoving.ValidMoves.Push(dstPos);


                        if (pcMoving.PieceColor == ChessPieceColor.White)
                        {
                            WhiteAttackBoard[dstPos] = true;
                        }
                        else
                        {
                            BlackAttackBoard[dstPos] = true;
                        }
                    }
                }
            }

            Piece pcAttacked = board.Squares[dstPos].Piece;
            //If there no piece there I can potentialy kill_
            if (pcAttacked == null)
                return;
            //Regardless of what is there I am attacking this square_
            if (pcMoving.PieceColor == ChessPieceColor.White)
            {
                WhiteAttackBoard[dstPos] = true;
                //if that piece is the same color_
                if (pcAttacked.PieceColor == pcMoving.PieceColor)
                {
                    pcAttacked.DefendedValue += pcMoving.PieceActionValue;
                    return;
                }
                //else piece is different so we are attacking_
                pcAttacked.AttackedValue += pcMoving.PieceActionValue;
                //If this is a king set it in check 
                if (pcAttacked.PieceType == ChessPieceType.King)
                {
                    board.BlackCheck = true;
                }
                else
                {
                    //Add this as a valid move_
                    pcMoving.ValidMoves.Push(dstPos);
                }
            }
            else
            {
                BlackAttackBoard[dstPos] = true;
                //if that piece is the same color_
                if (pcAttacked.PieceColor == pcMoving.PieceColor)
                {
                    return;
                }
                //If this is a king set it in check 
                if (pcAttacked.PieceType == ChessPieceType.King)
                {
                    board.WhiteCheck = true;
                }
                else
                {
                    //Add this as a valid move_
                    pcMoving.ValidMoves.Push(dstPos);
                }
            }
            return;
        }

        private static void GenerateValidMovesKingCastle(Board board, Piece king)
        {
            if (king == null)
            {
                return;
            }


            if (king.Moved)
            {
                return;
            }

            if (king.PieceColor == ChessPieceColor.White &&
             board.WhiteCastled)
            {
                return;
            }

            if (king.PieceColor == ChessPieceColor.Black &&
             board.BlackCastled)
            {
                return;
            }

            if (king.PieceColor == ChessPieceColor.Black &&
             board.BlackCheck)
            {
                return;
            }

            if (king.PieceColor == ChessPieceColor.White &&
             board.WhiteCheck)
            {
                return;
            }



            //This code will add the castleling move to the pieces available moves_
            if (king.PieceColor == ChessPieceColor.White)
            {
                if (board.WhiteCheck)
                {
                    return;
                }

                if (board.Squares[63].Piece != null)
                {
                    //Check if the Right Rook is still in the correct position_
                    if (board.Squares[63].Piece.PieceType == ChessPieceType.Rook)
                    {
                        if (board.Squares[63].Piece.PieceColor == king.PieceColor)
                        {
                            //Move one column to right see if its empty_
                            if (board.Squares[62].Piece == null)
                            {
                                if (board.Squares[61].Piece == null)
                                {
                                    if (BlackAttackBoard[61] == false &&
                                     BlackAttackBoard[62] == false)
                                    {
                                        //Ok looks like move is valid lets add it_
                                        king.ValidMoves.Push(62);
                                        WhiteAttackBoard[62] = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (board.Squares[56].Piece != null)
                {
                    //Check if the Left Rook is still in the correct position_
                    if (board.Squares[56].Piece.PieceType == ChessPieceType.Rook)
                    {
                        if (board.Squares[56].Piece.PieceColor == king.PieceColor)
                        {
                            //Move one column to right see if its empty_
                            if (board.Squares[57].Piece == null)
                            {
                                if (board.Squares[58].Piece == null)
                                {
                                    if (board.Squares[59].Piece == null)
                                    {
                                        if (BlackAttackBoard[58] == false &&
                                         BlackAttackBoard[59] == false)
                                        {
                                            //Ok looks like move is valid lets add it_
                                            king.ValidMoves.Push(58);
                                            WhiteAttackBoard[58] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (king.PieceColor == ChessPieceColor.Black)
            {
                if (board.BlackCheck)
                {
                    return;
                }
                //There are two ways to castle, scenario 1:_ 
                if (board.Squares[7].Piece != null)
                {
                    //Check if the Right Rook is still in the correct position_
                    if (board.Squares[7].Piece.PieceType == ChessPieceType.Rook
                     && !board.Squares[7].Piece.Moved)
                    {
                        if (board.Squares[7].Piece.PieceColor == king.PieceColor)
                        {
                            //Move one column to right see if its empty
                            if (board.Squares[6].Piece == null)
                            {
                                if (board.Squares[5].Piece == null)
                                {
                                    if (WhiteAttackBoard[5] == false && WhiteAttackBoard[6] == false)
                                    {
                                        //Ok looks like move is valid lets add it_
                                        king.ValidMoves.Push(6);
                                        BlackAttackBoard[6] = true;
                                    }
                                }
                            }
                        }
                    }
                }
                //There are two ways to castle, scenario 2:_
                if (board.Squares[0].Piece != null)
                {
                    //Check if the Left Rook is still in the correct position_
                    if (board.Squares[0].Piece.PieceType == ChessPieceType.Rook &&
                     !board.Squares[0].Piece.Moved)
                    {
                        if (board.Squares[0].Piece.PieceColor ==
                         king.PieceColor)
                        {
                            //Move one column to right see if its empty_
                            if (board.Squares[1].Piece == null)
                            {
                                if (board.Squares[2].Piece == null)
                                {
                                    if (board.Squares[3].Piece == null)
                                    {
                                        if (WhiteAttackBoard[2] == false &&
                                         WhiteAttackBoard[3] == false)
                                        {
                                            //Ok looks like move is valid lets add it_
                                            king.ValidMoves.Push(2);
                                            BlackAttackBoard[2] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void GenerateValidMoves(Board board)
        {
            // Reset Board
            board.BlackCheck = false;
            board.WhiteCheck = false;

            WhiteAttackBoard = new bool[64];
            BlackAttackBoard = new bool[64];

            //Generate Moves_
            for (byte x = 0; x < 64; x++)
            {
                Square sqr = board.Squares[x];
                if (sqr.Piece == null)
                    continue;

                sqr.Piece.ValidMoves = new Stack<byte>(sqr.Piece.LastValidMoveCount);
                switch (sqr.Piece.PieceType)
                {
                    case ChessPieceType.Pawn:
                        {
                            if (sqr.Piece.PieceColor == ChessPieceColor.White)
                            {
                                CheckValidMovesPawn(MoveArrays.WhitePawnMoves[x].Moves, sqr.Piece, x,
                                     board, MoveArrays.WhitePawnTotalMoves[x]);
                                break;
                            }

                            if (sqr.Piece.PieceColor == ChessPieceColor.Black)
                            {
                                CheckValidMovesPawn(MoveArrays.BlackPawnMoves[x].Moves, sqr.Piece, x, board,
                                     MoveArrays.BlackPawnTotalMoves[x]);
                                break;
                            }
                            break;
                        }

                    case ChessPieceType.Knight:
                        {
                            for (byte i = 0; i < MoveArrays.KnightTotalMoves[x]; i++)
                            {
                                AnalyzeMove(board, MoveArrays.KnightMoves[x].Moves[i], sqr.Piece);
                            }
                            break;
                        }

                    case ChessPieceType.Bishop:
                        {
                            for (byte i = 0; i < MoveArrays.BishopTotalMoves1[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.BishopMoves1[x].Moves[i],
                                    sqr.Piece) == false)
                                {
                                    break;
                                }

                            }

                            for (byte i = 0; i < MoveArrays.BishopTotalMoves2[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.BishopMoves2[x].Moves[i],
                                    sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.BishopTotalMoves3[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.BishopMoves3[x].Moves[i],
                                    sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.BishopTotalMoves4[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.BishopMoves4[x].Moves[i],
                                    sqr.Piece) == false)
                                {
                                    break;
                                }
                            }
                            break;
                        }

                    case ChessPieceType.Rook:
                        {
                            for (byte i = 0; i < MoveArrays.RookTotalMoves1[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.RookMoves1[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.RookTotalMoves2[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.RookMoves2[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.RookTotalMoves3[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.RookMoves3[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.RookTotalMoves4[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.RookMoves4[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }
                            break;
                        }

                    case ChessPieceType.Queen:
                        {
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves1[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves1[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves2[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves2[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves3[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves3[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves4[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves4[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves5[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves5[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves6[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves6[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves7[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves7[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves8[x]; i++)
                            {
                                if (AnalyzeMove(board, MoveArrays.QueenMoves8[x].Moves[i], sqr.Piece) == false)
                                {
                                    break;
                                }
                            }
                            break;
                        }

                    case ChessPieceType.King:
                        {
                            if (sqr.Piece.PieceColor == ChessPieceColor.White)
                            {
                                WhiteKingPosition = x;
                            }
                            else
                            {
                                BlackKingPosition = x;
                            }
                            break;
                        }
                }
            }



            //if (board.WhoseMove == ChessPieceColor.White)
            //{
            //    GenerateValidMovesKing(board.Squares[BlackKingPosition].Piece, board,
            //            BlackKingPosition);
            //    GenerateValidMovesKing(board.Squares[WhiteKingPosition].Piece, board,
            //            WhiteKingPosition);
            //}
            //else
            //{
            //    GenerateValidMovesKing(board.Squares[WhiteKingPosition].Piece, board,
            //            WhiteKingPosition);
            //    GenerateValidMovesKing(board.Squares[BlackKingPosition].Piece, board,
            //            BlackKingPosition);
            //}

            //Now that all the pieces were examined we know if the king is in check_
            GenerateValidMovesKingCastle(board, board.Squares[WhiteKingPosition].Piece);
            GenerateValidMovesKingCastle(board, board.Squares[BlackKingPosition].Piece);
        }


    }

    internal class MoveContent
    {
        internal PieceMoving MovingPiecePrimary;
        internal PieceMoving MovingPieceSecondary;
        internal PieceTaken TakenPiece;

        internal int Score;
        internal bool PawnPromoted;
        internal bool EnPassantOccured;

        internal MoveContent() { }

        internal MoveContent(MoveContent lastMove)
        {
            lastMove.MovingPiecePrimary = this.MovingPiecePrimary;
            lastMove.MovingPieceSecondary = this.MovingPieceSecondary;
            lastMove.TakenPiece = this.TakenPiece;
            lastMove.Score = this.Score;
            lastMove.PawnPromoted = this.PawnPromoted;
            lastMove.EnPassantOccured = this.EnPassantOccured;
        }

        public new string ToString()
        {
            string value = "";

            var srcCol = (byte)(MovingPiecePrimary.SrcPosition % 8);
            var srcRow = (byte)(8 - (MovingPiecePrimary.SrcPosition / 8));
            var dstCol = (byte)(MovingPiecePrimary.DstPosition % 8);
            var dstRow = (byte)(8 - (MovingPiecePrimary.DstPosition / 8));
            if (MovingPieceSecondary.PieceType == ChessPieceType.Rook)
            {
                if (MovingPieceSecondary.PieceColor == ChessPieceColor.Black)
                {
                    if (MovingPieceSecondary.SrcPosition == 7)
                    {
                        value += "O-O";
                    }
                    else if (MovingPieceSecondary.SrcPosition == 0)
                    {
                        value += "O-O-O";
                    }
                }

                else if (MovingPieceSecondary.PieceColor == ChessPieceColor.White)
                {
                    if (MovingPieceSecondary.SrcPosition == 63)
                    {
                        value += "O-O";
                    }
                    else if (MovingPieceSecondary.SrcPosition == 56)
                    {
                        value += "O-O-O";
                    }
                }
            }

            else
            {
                value += GetPgnMove(MovingPiecePrimary.PieceType);
                switch (MovingPiecePrimary.PieceType)
                {
                    case ChessPieceType.Knight:
                        value += GetColumnFromInt(srcCol + 1);
                        value += srcRow;
                        break;
                    case ChessPieceType.Rook:
                        value += GetColumnFromInt(srcCol + 1);
                        value += srcRow;
                        break;
                    case ChessPieceType.Pawn:
                        if (srcCol != dstCol)
                        {
                            value += GetColumnFromInt(srcCol + 1);
                        }
                        break;
                }

                if (TakenPiece.PieceType != ChessPieceType.None)
                {
                    value += "x";
                }

                value += GetColumnFromInt(dstCol + 1);
                value += dstRow;
                if (PawnPromoted)
                {
                    value += "=Q";
                }
            }
            return value;

        }

        private static string GetColumnFromInt(int column)
        {
            return column switch
            {
                1 => "a",
                2 => "b",
                3 => "c",
                4 => "d",
                5 => "e",
                6 => "f",
                7 => "g",
                8 => "h",
                _ => "Unknown",
            };
        }

        private static string GetPgnMove(ChessPieceType pieceType)
        {
            return pieceType switch
            {
                ChessPieceType.Bishop => "B",
                ChessPieceType.King => "K",
                ChessPieceType.Knight => "N",
                ChessPieceType.Queen => "Q",
                ChessPieceType.Rook => "R",
                _ => "",
            };
        }
    }

    public struct PieceMoving
    {
        public byte DstPosition;
        public bool Moved;
        public ChessPieceColor PieceColor;
        public ChessPieceType PieceType;
        public byte SrcPosition;

        public PieceMoving(ChessPieceColor pieceColor, ChessPieceType pieceType, bool moved,
               byte srcPosition, byte dstPosition)
        {
            PieceColor = pieceColor;
            PieceType = pieceType;
            SrcPosition = srcPosition;
            DstPosition = dstPosition;
            Moved = moved;
        }

        public PieceMoving(PieceMoving pieceMoving)
        {
            PieceColor = pieceMoving.PieceColor;
            PieceType = pieceMoving.PieceType;
            SrcPosition = pieceMoving.SrcPosition;
            DstPosition = pieceMoving.DstPosition;
            Moved = pieceMoving.Moved;
        }

        public PieceMoving(ChessPieceType pieceType)
        {
            PieceType = pieceType;
            PieceColor = ChessPieceColor.White;
            SrcPosition = 0;
            DstPosition = 0;
            Moved = false;
        }
    }

    public struct PieceTaken
    {
        public bool Moved;
        public ChessPieceColor PieceColor;
        public ChessPieceType PieceType;
        public byte Position;


        public PieceTaken(ChessPieceColor pieceColor, ChessPieceType pieceType, bool moved,
              byte position)
        {
            PieceColor = pieceColor;
            PieceType = pieceType;
            Position = position;
            Moved = moved;
        }

        public PieceTaken(ChessPieceType pieceType)
        {
            PieceColor = ChessPieceColor.White;
            PieceType = pieceType;
            Position = 0;
            Moved = false;
        }
    }


}
