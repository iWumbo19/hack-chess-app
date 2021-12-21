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
        Dictionary<ChessPieceType, Bitmap> BlackPieceImage = new Dictionary<ChessPieceType, Bitmap>()
        {
            {ChessPieceType.Pawn, Properties.Resources.B_Pawn },
            {ChessPieceType.Knight, Properties.Resources.B_Knight },
            {ChessPieceType.Bishop, Properties.Resources.B_Bishop },
            {ChessPieceType.Queen, Properties.Resources.B_Queen },
            {ChessPieceType.King, Properties.Resources.B_King },
            {ChessPieceType.Rook, Properties.Resources.B_Rook }
        };

        Dictionary<ChessPieceType, Bitmap> WhitePieceImage = new Dictionary<ChessPieceType, Bitmap>()
        {
            {ChessPieceType.Pawn, Properties.Resources.W_Pawn },
            {ChessPieceType.Knight, Properties.Resources.W_Knight },
            {ChessPieceType.Bishop, Properties.Resources.W_Bishop },
            {ChessPieceType.Queen, Properties.Resources.W_Queen },
            {ChessPieceType.King, Properties.Resources.W_King },
            {ChessPieceType.Rook, Properties.Resources.W_Rook }
        };

        private bool choosingDst = false;
        private byte _srcSquare;
        private byte _dstSquare;

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
            if (CurrentBoard.Squares[0].Piece != null)
                SquareA8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[0].Piece.PieceColor, CurrentBoard.Squares[0].Piece.PieceType);
            if (CurrentBoard.Squares[1].Piece != null)
                SquareB8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[1].Piece.PieceColor, CurrentBoard.Squares[1].Piece.PieceType);
            if (CurrentBoard.Squares[2].Piece != null)
                SquareC8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[2].Piece.PieceColor, CurrentBoard.Squares[2].Piece.PieceType);
            if (CurrentBoard.Squares[3].Piece != null)
                SquareD8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[3].Piece.PieceColor, CurrentBoard.Squares[3].Piece.PieceType);
            if (CurrentBoard.Squares[4].Piece != null)
                SquareE8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[4].Piece.PieceColor, CurrentBoard.Squares[4].Piece.PieceType);
            if (CurrentBoard.Squares[5].Piece != null)
                SquareF8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[5].Piece.PieceColor, CurrentBoard.Squares[5].Piece.PieceType);
            if (CurrentBoard.Squares[6].Piece != null)
                SquareG8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[6].Piece.PieceColor, CurrentBoard.Squares[6].Piece.PieceType);
            if (CurrentBoard.Squares[7].Piece != null)
                SquareH8.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[7].Piece.PieceColor, CurrentBoard.Squares[7].Piece.PieceType);

            if (CurrentBoard.Squares[8].Piece != null)
                SquareA7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[8].Piece.PieceColor, CurrentBoard.Squares[8].Piece.PieceType);
            if (CurrentBoard.Squares[9].Piece != null)
                SquareB7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[9].Piece.PieceColor, CurrentBoard.Squares[9].Piece.PieceType);
            if (CurrentBoard.Squares[10].Piece != null)
                SquareC7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[10].Piece.PieceColor, CurrentBoard.Squares[10].Piece.PieceType);
            if (CurrentBoard.Squares[11].Piece != null)
                SquareD7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[11].Piece.PieceColor, CurrentBoard.Squares[11].Piece.PieceType);
            if (CurrentBoard.Squares[12].Piece != null)
                SquareE7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[12].Piece.PieceColor, CurrentBoard.Squares[12].Piece.PieceType);
            if (CurrentBoard.Squares[13].Piece != null)
                SquareF7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[13].Piece.PieceColor, CurrentBoard.Squares[13].Piece.PieceType);
            if (CurrentBoard.Squares[14].Piece != null)
                SquareG7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[14].Piece.PieceColor, CurrentBoard.Squares[14].Piece.PieceType);
            if (CurrentBoard.Squares[15].Piece != null)
                SquareH7.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[15].Piece.PieceColor, CurrentBoard.Squares[15].Piece.PieceType);

            if (CurrentBoard.Squares[16].Piece != null)
                SquareA6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[16].Piece.PieceColor, CurrentBoard.Squares[16].Piece.PieceType);
            if (CurrentBoard.Squares[17].Piece != null)
                SquareB6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[17].Piece.PieceColor, CurrentBoard.Squares[17].Piece.PieceType);
            if (CurrentBoard.Squares[18].Piece != null)
                SquareC6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[18].Piece.PieceColor, CurrentBoard.Squares[18].Piece.PieceType);
            if (CurrentBoard.Squares[19].Piece != null)
                SquareD6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[19].Piece.PieceColor, CurrentBoard.Squares[19].Piece.PieceType);
            if (CurrentBoard.Squares[20].Piece != null)
                SquareE6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[20].Piece.PieceColor, CurrentBoard.Squares[20].Piece.PieceType);
            if (CurrentBoard.Squares[21].Piece != null)
                SquareF6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[21].Piece.PieceColor, CurrentBoard.Squares[21].Piece.PieceType);
            if (CurrentBoard.Squares[22].Piece != null)
                SquareG6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[22].Piece.PieceColor, CurrentBoard.Squares[22].Piece.PieceType);
            if (CurrentBoard.Squares[23].Piece != null)
                SquareH6.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[23].Piece.PieceColor, CurrentBoard.Squares[23].Piece.PieceType);

            if (CurrentBoard.Squares[24].Piece != null)
                SquareA5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[24].Piece.PieceColor, CurrentBoard.Squares[24].Piece.PieceType);
            if (CurrentBoard.Squares[25].Piece != null)
                SquareB5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[25].Piece.PieceColor, CurrentBoard.Squares[25].Piece.PieceType);
            if (CurrentBoard.Squares[26].Piece != null)
                SquareC5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[26].Piece.PieceColor, CurrentBoard.Squares[26].Piece.PieceType);
            if (CurrentBoard.Squares[27].Piece != null)
                SquareD5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[27].Piece.PieceColor, CurrentBoard.Squares[27].Piece.PieceType);
            if (CurrentBoard.Squares[28].Piece != null)
                SquareE5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[28].Piece.PieceColor, CurrentBoard.Squares[28].Piece.PieceType);
            if (CurrentBoard.Squares[29].Piece != null)
                SquareF5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[29].Piece.PieceColor, CurrentBoard.Squares[29].Piece.PieceType);
            if (CurrentBoard.Squares[30].Piece != null)
                SquareG5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[30].Piece.PieceColor, CurrentBoard.Squares[30].Piece.PieceType);
            if (CurrentBoard.Squares[31].Piece != null)
                SquareH5.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[31].Piece.PieceColor, CurrentBoard.Squares[31].Piece.PieceType);

            if (CurrentBoard.Squares[32].Piece != null)
                SquareA4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[32].Piece.PieceColor, CurrentBoard.Squares[32].Piece.PieceType);
            if (CurrentBoard.Squares[33].Piece != null)
                SquareB4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[33].Piece.PieceColor, CurrentBoard.Squares[33].Piece.PieceType);
            if (CurrentBoard.Squares[34].Piece != null)
                SquareC4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[34].Piece.PieceColor, CurrentBoard.Squares[34].Piece.PieceType);
            if (CurrentBoard.Squares[35].Piece != null)
                SquareD4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[35].Piece.PieceColor, CurrentBoard.Squares[35].Piece.PieceType);
            if (CurrentBoard.Squares[36].Piece != null)
                SquareE4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[36].Piece.PieceColor, CurrentBoard.Squares[36].Piece.PieceType);
            if (CurrentBoard.Squares[37].Piece != null)
                SquareF4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[37].Piece.PieceColor, CurrentBoard.Squares[37].Piece.PieceType);
            if (CurrentBoard.Squares[38].Piece != null)
                SquareG4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[38].Piece.PieceColor, CurrentBoard.Squares[38].Piece.PieceType);
            if (CurrentBoard.Squares[39].Piece != null)
                SquareH4.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[39].Piece.PieceColor, CurrentBoard.Squares[39].Piece.PieceType);

            if (CurrentBoard.Squares[40].Piece != null)
                SquareA3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[40].Piece.PieceColor, CurrentBoard.Squares[40].Piece.PieceType);
            if (CurrentBoard.Squares[41].Piece != null)
                SquareB3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[41].Piece.PieceColor, CurrentBoard.Squares[41].Piece.PieceType);
            if (CurrentBoard.Squares[42].Piece != null)
                SquareC3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[42].Piece.PieceColor, CurrentBoard.Squares[42].Piece.PieceType);
            if (CurrentBoard.Squares[43].Piece != null)
                SquareD3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[43].Piece.PieceColor, CurrentBoard.Squares[43].Piece.PieceType);
            if (CurrentBoard.Squares[44].Piece != null)
                SquareE3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[44].Piece.PieceColor, CurrentBoard.Squares[44].Piece.PieceType);
            if (CurrentBoard.Squares[45].Piece != null)
                SquareF3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[45].Piece.PieceColor, CurrentBoard.Squares[45].Piece.PieceType);
            if (CurrentBoard.Squares[46].Piece != null)
                SquareG3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[46].Piece.PieceColor, CurrentBoard.Squares[46].Piece.PieceType);
            if (CurrentBoard.Squares[47].Piece != null)
                SquareH3.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[47].Piece.PieceColor, CurrentBoard.Squares[47].Piece.PieceType);

            if (CurrentBoard.Squares[48].Piece != null)
                SquareA2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[48].Piece.PieceColor, CurrentBoard.Squares[48].Piece.PieceType);
            if (CurrentBoard.Squares[49].Piece != null)
                SquareB2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[49].Piece.PieceColor, CurrentBoard.Squares[49].Piece.PieceType);
            if (CurrentBoard.Squares[50].Piece != null)
                SquareC2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[50].Piece.PieceColor, CurrentBoard.Squares[50].Piece.PieceType);
            if (CurrentBoard.Squares[51].Piece != null)
                SquareD2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[51].Piece.PieceColor, CurrentBoard.Squares[51].Piece.PieceType);
            if (CurrentBoard.Squares[52].Piece != null)
                SquareE2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[52].Piece.PieceColor, CurrentBoard.Squares[52].Piece.PieceType);
            if (CurrentBoard.Squares[53].Piece != null)
                SquareF2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[53].Piece.PieceColor, CurrentBoard.Squares[53].Piece.PieceType);
            if (CurrentBoard.Squares[54].Piece != null)
                SquareG2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[54].Piece.PieceColor, CurrentBoard.Squares[54].Piece.PieceType);
            if (CurrentBoard.Squares[55].Piece != null)
                SquareH2.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[55].Piece.PieceColor, CurrentBoard.Squares[55].Piece.PieceType);

            if (CurrentBoard.Squares[56].Piece != null)
                SquareA1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[56].Piece.PieceColor, CurrentBoard.Squares[56].Piece.PieceType);
            if (CurrentBoard.Squares[57].Piece != null)
                SquareB1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[57].Piece.PieceColor, CurrentBoard.Squares[57].Piece.PieceType);
            if (CurrentBoard.Squares[58].Piece != null)
                SquareC1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[58].Piece.PieceColor, CurrentBoard.Squares[58].Piece.PieceType);
            if (CurrentBoard.Squares[59].Piece != null)
                SquareD1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[59].Piece.PieceColor, CurrentBoard.Squares[59].Piece.PieceType);
            if (CurrentBoard.Squares[60].Piece != null)
                SquareE1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[60].Piece.PieceColor, CurrentBoard.Squares[60].Piece.PieceType);
            if (CurrentBoard.Squares[61].Piece != null)
                SquareF1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[61].Piece.PieceColor, CurrentBoard.Squares[61].Piece.PieceType);
            if (CurrentBoard.Squares[62].Piece != null)
                SquareG1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[62].Piece.PieceColor, CurrentBoard.Squares[62].Piece.PieceType);
            if (CurrentBoard.Squares[63].Piece != null)
                SquareH1.BackgroundImage = RetrievePieceImage(CurrentBoard.Squares[63].Piece.PieceColor, CurrentBoard.Squares[63].Piece.PieceType);
        }

        private Bitmap RetrievePieceImage(ChessPieceColor color, ChessPieceType type)
        {
            if (color == ChessPieceColor.White) { return WhitePieceImage[type]; }
            else { return BlackPieceImage[type]; }
        }

        private void SquareA8_Click(object sender, EventArgs e)
        {
            if (choosingDst)
            {

            }
            else
            {
                
            }
        }
    }
}

