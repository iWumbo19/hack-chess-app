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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Draw_Button_Click(object sender, RoutedEventArgs e)
        {
            SquareA8.Content = FindResource("B_Rook");
                

        }

        private Bitmap RetrievePieceImage(ChessPieceColor color, ChessPieceType type)
        {
            if (color == ChessPieceColor.White) { return WhitePieceImage[type]; }
            else { return BlackPieceImage[type]; }
        }
    }
}
