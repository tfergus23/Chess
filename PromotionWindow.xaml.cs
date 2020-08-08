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
using System.Windows.Shapes;
using Chess.Pieces;
using Chess.Board;

namespace Chess
{
    /// <summary>
    /// Interaction logic for PromotionWindow.xaml
    /// </summary>
    public partial class PromotionWindow : Window
    {
        Player player;
        GameWindow gameWindow;
        Boolean closedManually = true;
        public PromotionWindow(Player player, GameWindow window)
        {
            InitializeComponent();
            this.Title = "Promote your pawn!";
            this.player = player;
            this.gameWindow = window;
            //Rook
            Image rookImage = new Image();
            rookImage.Width = 60;
            rookImage.Height = 60;
            rookImage.MouseUp += rookSelected;
            Grid.SetColumn(rookImage, 0);
            Grid.SetRow(rookImage, 0);

            //Bishop
            Image bishopImage = new Image();
            bishopImage.Width = 60;
            bishopImage.Height = 60;
            bishopImage.MouseUp += bishopSelected;
            Grid.SetColumn(bishopImage, 1);
            Grid.SetRow(bishopImage, 0);

            //Queen
            Image queenImage = new Image();
            queenImage.Width = 60;
            queenImage.Height = 60;
            queenImage.MouseUp += queenSelected;
            Grid.SetColumn(queenImage, 2);
            Grid.SetRow(queenImage, 0);

            //Knight
            Image knightImage = new Image();
            knightImage.Width = 60;
            knightImage.Height = 60;
            knightImage.MouseUp += knightSelected;
            Grid.SetColumn(knightImage, 3);
            Grid.SetRow(knightImage, 0);

            if (player == Player.Player1)
            {
                //Rook
                BitmapImage temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/white_rook.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                rookImage.Source = temp;

                //Bishop
                temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/white_bishop.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                bishopImage.Source = temp;

                //Queen
                temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/white_queen.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                queenImage.Source = temp;

                temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/white_knight.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                knightImage.Source = temp;
            }
            else
            {
                //Rook
                BitmapImage temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/black_rook.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                rookImage.Source = temp;

                //Bishop
                temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/black_bishop.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                bishopImage.Source = temp;

                //Queen
                temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/black_queen.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                queenImage.Source = temp;

                temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(@"/Images/Pieces/black_knight.png", UriKind.RelativeOrAbsolute);
                temp.EndInit();
                knightImage.Source = temp;
            }
            PieceGrid.Children.Add(rookImage);
            PieceGrid.Children.Add(bishopImage);
            PieceGrid.Children.Add(queenImage);
            PieceGrid.Children.Add(knightImage);
        }

        private void rookSelected(Object sender, MouseButtonEventArgs e)
        {
            closedManually = false;
            gameWindow.promote(PieceType.Rook);
            this.Close();
        }

        private void bishopSelected(Object sender, MouseButtonEventArgs e)
        {
            closedManually = false;
            gameWindow.promote(PieceType.Bishop);
            this.Close();
        }

        private void queenSelected(Object sender, MouseButtonEventArgs e)
        {
            closedManually = false;
            gameWindow.promote(PieceType.Queen);
            this.Close();
        }

        private void knightSelected(Object sender, MouseButtonEventArgs e)
        {
            closedManually = false;
            gameWindow.promote(PieceType.Knight);
            this.Close();
        }
        
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (closedManually)
            {
                e.Cancel = true;
                this.Hide();
                MessageBox.Show("You must select a piece!");
                this.Show();
            }
            else
            {
                e.Cancel = false;
            }

        }
        
    }
}
