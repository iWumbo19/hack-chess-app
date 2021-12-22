using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal struct Square
    {
        internal Piece Piece;

        internal Square(Piece piece)
        {
            Piece = new Piece(piece);
        }
    }
}
