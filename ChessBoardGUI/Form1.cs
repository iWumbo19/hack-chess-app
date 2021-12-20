using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGUI
{
    public partial class GameBoard : Form
    {
        Dictionary<ChessPieceType, string> BlackPieceImage = new Dictionary<ChessPieceType, string>()
        {
            {ChessPieceType.Pawn, @"\Resources\Piece\B_Pawn.png" },
            {ChessPieceType.Knight, @"\Resources\Piece\B_Knight.png" },
            {ChessPieceType.Bishop, @"\Resources\Piece\B_Bishop.png" },
            {ChessPieceType.Queen, @"\Resources\Piece\B_Queen.png" },
            {ChessPieceType.King, @"\Resources\Piece\B_King.png" },
            {ChessPieceType.Rook, @"\Resources\Piece\B_Rook.png" }
        };
        public GameBoard()
        {
            InitializeComponent();
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            CurrentBoard.SetupBoard();
            ReDrawBoard();
        }

        private void ReDrawBoard()
        {
            if (CurrentBoard.Squares[0].Piece != null) {
                SquareA8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[0].Piece.PieceColor, CurrentBoard.Squares[0].Piece.PieceType)
        }

        private Bitmap RetrievePieceImage(ChessPieceColor color, ChessPieceType type)
        {

        }
    }
}
