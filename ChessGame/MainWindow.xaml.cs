using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Resources;
using System.Drawing;

namespace ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Draw_Button_Click(object sender, RoutedEventArgs e)
        {
            var brush = new ImageBrush();
            CurrentBoard.SetupBoard();
            if (CurrentBoard.Squares[(byte)BoardtoByte.A8].Piece != null)
                SquareA8 = GetPieceImage(CurrentBoard.Squares[(byte)BoardtoByte.A8].Piece.PieceColor,
                                            CurrentBoard.Squares[(byte)BoardtoByte.A8].Piece.PieceType);

        }

        public Bitmap GetPieceImage(ChessPieceColor color, ChessPieceType type)
        {
            ImageConverter ic = new ImageConverter();
            if (color == ChessPieceColor.White)
            {
                switch (type)
                {
                    case ChessPieceType.King:                        
                        System.Drawing.Image img = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.W_King);
                        return new Bitmap(img);
                    case ChessPieceType.Queen:
                        System.Drawing.Image img2 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.W_Queen);
                        return new Bitmap(img2);
                    case ChessPieceType.Rook:
                        System.Drawing.Image img3 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.W_Rook);
                        return new Bitmap(img3);
                    case ChessPieceType.Bishop:
                        System.Drawing.Image img4 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.W_Bishop);
                        return new Bitmap(img4);
                    case ChessPieceType.Knight:
                        System.Drawing.Image img5 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.W_Knight);
                        return new Bitmap(img5);
                    case ChessPieceType.Pawn:
                        System.Drawing.Image img6 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.W_Pawn);
                        return new Bitmap(img6);
                    default:
                        System.Drawing.Image img7 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.Empty);
                        return new Bitmap(img7);
                }
            }
            else
            {
                switch (type)
                {
                    case ChessPieceType.King:
                        System.Drawing.Image img = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.B_King);
                        return new Bitmap(img);
                    case ChessPieceType.Queen:
                        System.Drawing.Image img2 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.B_Queen);
                        return new Bitmap(img2);
                    case ChessPieceType.Rook:
                        System.Drawing.Image img3 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.B_Rook);
                        return new Bitmap(img3);
                    case ChessPieceType.Bishop:
                        System.Drawing.Image img4 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.B_Bishop);
                        return new Bitmap(img4);
                    case ChessPieceType.Knight:
                        System.Drawing.Image img5 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.B_Knight);
                        return new Bitmap(img5);
                    case ChessPieceType.Pawn:
                        System.Drawing.Image img6 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.B_Pawn);
                        return new Bitmap(img6);
                    default:
                        System.Drawing.Image img7 = (System.Drawing.Image)ic.ConvertFrom(Properties.Resources.Empty);
                        return new Bitmap(img7);
                }
            }
        }
    }
}
