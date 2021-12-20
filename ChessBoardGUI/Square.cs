using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGUI
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
