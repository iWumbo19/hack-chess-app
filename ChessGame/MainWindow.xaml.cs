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
using System.IO;
using System.Drawing.Imaging;

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

        private byte _sourceSelection = 64;
        private byte _destSelection = 64;

        public MainWindow()
        {
            InitializeComponent();
            BoardBG.Source = ToBitmapImage(Properties.Resources.Green_Board);
            PieceMoves.InitiateChessPieceMotion();
            CurrentBoard.SetupBoard();
            DrawAll();
        }

        private BitmapImage RetrievePieceImage(ChessPieceColor color, ChessPieceType type)
        {            
            if (color == ChessPieceColor.White) { return ToBitmapImage(WhitePieceImage[type]); }
            else { return ToBitmapImage(BlackPieceImage[type]); }
        }
        private BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }



        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentBoard.SetupBoard();
            DrawAll();
        }

        private void DrawAll()
        {
            if (CurrentBoard.Squares[(int)BoardtoByte.A8].Piece != null) { SquareA8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A8].Piece.PieceType); } else { SquareA8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B8].Piece != null) { SquareB8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B8].Piece.PieceType); } else { SquareB8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C8].Piece != null) { SquareC8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C8].Piece.PieceType); } else { SquareC8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D8].Piece != null) { SquareD8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D8].Piece.PieceType); } else { SquareD8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E8].Piece != null) { SquareE8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E8].Piece.PieceType); } else { SquareE8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F8].Piece != null) { SquareF8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F8].Piece.PieceType); } else { SquareF8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G8].Piece != null) { SquareG8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G8].Piece.PieceType); } else { SquareG8.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H8].Piece != null) { SquareH8.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H8].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H8].Piece.PieceType); } else { SquareH8.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A7].Piece != null) { SquareA7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A7].Piece.PieceType); } else { SquareA7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B7].Piece != null) { SquareB7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B7].Piece.PieceType); } else { SquareB7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C7].Piece != null) { SquareC7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C7].Piece.PieceType); } else { SquareC7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D7].Piece != null) { SquareD7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D7].Piece.PieceType); } else { SquareD7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E7].Piece != null) { SquareE7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E7].Piece.PieceType); } else { SquareE7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F7].Piece != null) { SquareF7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F7].Piece.PieceType); } else { SquareF7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G7].Piece != null) { SquareG7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G7].Piece.PieceType); } else { SquareG7.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H7].Piece != null) { SquareH7.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H7].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H7].Piece.PieceType); } else { SquareH7.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A6].Piece != null) { SquareA6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A6].Piece.PieceType); } else { SquareA6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B6].Piece != null) { SquareB6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B6].Piece.PieceType); } else { SquareB6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C6].Piece != null) { SquareC6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C6].Piece.PieceType); } else { SquareC6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D6].Piece != null) { SquareD6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D6].Piece.PieceType); } else { SquareD6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E6].Piece != null) { SquareE6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E6].Piece.PieceType); } else { SquareE6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F6].Piece != null) { SquareF6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F6].Piece.PieceType); } else { SquareF6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G6].Piece != null) { SquareG6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G6].Piece.PieceType); } else { SquareG6.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H6].Piece != null) { SquareH6.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H6].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H6].Piece.PieceType); } else { SquareH6.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A5].Piece != null) { SquareA5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A5].Piece.PieceType); } else { SquareA5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B5].Piece != null) { SquareB5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B5].Piece.PieceType); } else { SquareB5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C5].Piece != null) { SquareC5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C5].Piece.PieceType); } else { SquareC5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D5].Piece != null) { SquareD5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D5].Piece.PieceType); } else { SquareD5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E5].Piece != null) { SquareE5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E5].Piece.PieceType); } else { SquareE5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F5].Piece != null) { SquareF5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F5].Piece.PieceType); } else { SquareF5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G5].Piece != null) { SquareG5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G5].Piece.PieceType); } else { SquareG5.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H5].Piece != null) { SquareH5.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H5].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H5].Piece.PieceType); } else { SquareH5.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A4].Piece != null) { SquareA4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A4].Piece.PieceType); } else { SquareA4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B4].Piece != null) { SquareB4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B4].Piece.PieceType); } else { SquareB4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C4].Piece != null) { SquareC4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C4].Piece.PieceType); } else { SquareC4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D4].Piece != null) { SquareD4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D4].Piece.PieceType); } else { SquareD4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E4].Piece != null) { SquareE4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E4].Piece.PieceType); } else { SquareE4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F4].Piece != null) { SquareF4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F4].Piece.PieceType); } else { SquareF4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G4].Piece != null) { SquareG4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G4].Piece.PieceType); } else { SquareG4.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H4].Piece != null) { SquareH4.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H4].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H4].Piece.PieceType); } else { SquareH4.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A3].Piece != null) { SquareA3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A3].Piece.PieceType); } else { SquareA3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B3].Piece != null) { SquareB3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B3].Piece.PieceType); } else { SquareB3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C3].Piece != null) { SquareC3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C3].Piece.PieceType); } else { SquareC3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D3].Piece != null) { SquareD3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D3].Piece.PieceType); } else { SquareD3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E3].Piece != null) { SquareE3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E3].Piece.PieceType); } else { SquareE3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F3].Piece != null) { SquareF3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F3].Piece.PieceType); } else { SquareF3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G3].Piece != null) { SquareG3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G3].Piece.PieceType); } else { SquareG3.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H3].Piece != null) { SquareH3.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H3].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H3].Piece.PieceType); } else { SquareH3.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A2].Piece != null) { SquareA2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A2].Piece.PieceType); } else { SquareA2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B2].Piece != null) { SquareB2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B2].Piece.PieceType); } else { SquareB2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C2].Piece != null) { SquareC2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C2].Piece.PieceType); } else { SquareC2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D2].Piece != null) { SquareD2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D2].Piece.PieceType); } else { SquareD2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E2].Piece != null) { SquareE2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E2].Piece.PieceType); } else { SquareE2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F2].Piece != null) { SquareF2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F2].Piece.PieceType); } else { SquareF2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G2].Piece != null) { SquareG2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G2].Piece.PieceType); } else { SquareG2.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H2].Piece != null) { SquareH2.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H2].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H2].Piece.PieceType); } else { SquareH2.Source = ToBitmapImage(Properties.Resources.Empty); }

            if (CurrentBoard.Squares[(int)BoardtoByte.A1].Piece != null) { SquareA1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.A1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.A1].Piece.PieceType); } else { SquareA1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.B1].Piece != null) { SquareB1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.B1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.B1].Piece.PieceType); } else { SquareB1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.C1].Piece != null) { SquareC1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.C1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.C1].Piece.PieceType); } else { SquareC1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.D1].Piece != null) { SquareD1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.D1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.D1].Piece.PieceType); } else { SquareD1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.E1].Piece != null) { SquareE1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.E1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.E1].Piece.PieceType); } else { SquareE1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.F1].Piece != null) { SquareF1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.F1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.F1].Piece.PieceType); } else { SquareF1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.G1].Piece != null) { SquareG1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.G1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.G1].Piece.PieceType); } else { SquareG1.Source = ToBitmapImage(Properties.Resources.Empty); }
            if (CurrentBoard.Squares[(int)BoardtoByte.H1].Piece != null) { SquareH1.Source = RetrievePieceImage(CurrentBoard.Squares[(int)BoardtoByte.H1].Piece.PieceColor, CurrentBoard.Squares[(int)BoardtoByte.H1].Piece.PieceType); } else { SquareH1.Source = ToBitmapImage(Properties.Resources.Empty); }

            PieceValidMoves.GenerateValidMoves();
        }

        private bool IsValidSource(byte square)
        {
            if (CurrentBoard.Squares[square].Piece != null &&
                CurrentBoard.Squares[square].Piece.PieceColor == CurrentBoard.WhoseMove &&
                _sourceSelection == 64)
            {
                Status.Text = "Source Selected";
                return true;
            }
            Status.Text = "Not a valid Source";
            return false;
        }

        private bool IsValidDestination()
        {
            if (CurrentBoard.Squares[_sourceSelection].Piece.ValidMoves.Contains(_destSelection))
            {
                return true;
            }
            Status.Text = "Not a valid Destination";
            return false;
        }

        private void InitiateMove()
        {
            CurrentBoard.Squares[_destSelection].Piece = CurrentBoard.Squares[_sourceSelection].Piece;
            CurrentBoard.Squares[_sourceSelection].Piece = null;
            DrawAll();
            _sourceSelection = 64;
            _destSelection = 64;
            if (CurrentBoard.WhoseMove == ChessPieceColor.White) { CurrentBoard.WhoseMove = ChessPieceColor.Black; }
            else { CurrentBoard.WhoseMove = ChessPieceColor.White; }
            WhoseMoveText.Content = CurrentBoard.WhoseMove;
        }


        private void SquareClicked(object sender, MouseButtonEventArgs e)
        {
            byte index = Convert.ToByte(int.Parse((string)((System.Windows.Controls.Image)sender).Tag));
            if (_sourceSelection == 64) { if (IsValidSource(index)) { _sourceSelection = index; } }
            else
            {
                _destSelection = index;
                if (IsValidDestination())
                {
                    Status.Text = "Destination Selected";
                    InitiateMove();
                }
                else { _sourceSelection = 64; _destSelection = 64; Status.Text = "That is not a Legal Move"; }
            }
        }
    }
}
