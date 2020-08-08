using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chess.Board;
using Chess.Pieces;

namespace Chess
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameBoard board;
        Coordinate selectedSpace = null;
        MainWindow mainWindow;

        public GameWindow(MainWindow mw)
        {
            InitializeComponent();
            this.Title = "Chess Match";
            board = new GameBoard();
            updateBoard();
            mainWindow = mw;
        }

        //Displays the valid moves for the selected piece, assuming the piece can currently move.
        private void PieceSelected(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Image selected = (Image)sender;
                int selectedX = Grid.GetColumn(selected);
                int selectedY = 7 - Grid.GetRow(selected);
                Piece selectedPiece = board.getSpace(selectedX, selectedY);

                if (selectedPiece.player != board.whosTurn()) return;

                if (selectedSpace != null && selectedSpace.x == selectedX && selectedSpace.y == selectedY)
                {
                    validSpaceGrid.Children.Clear();
                    selectedSpace = null;
                    return;
                }
                else
                {
                    validSpaceGrid.Children.Clear();
                    selectedSpace = new Coordinate(selectedX, selectedY);
                    foreach (Coordinate coord in selectedPiece.getValidMoves(board))
                    {
                        Image image = new Image();
                        image.Width = 60;
                        image.Height = 60;
                        BitmapImage temp = new BitmapImage();
                        temp.BeginInit();

                        temp.UriSource = new Uri(@"/Images/Spaces/valid_space.png", UriKind.RelativeOrAbsolute);
                        temp.EndInit();
                        image.Source = temp;
                        image.MouseUp += DestinationSelected;

                        Grid.SetColumn(image, coord.x);
                        Grid.SetRow(image, 7 - coord.y);
                        validSpaceGrid.Children.Add(image);
                    }


                }

            }
            catch (Exception error)
            {
                String errorString = "Oopsie woopsie! Tom made a mistake!\nPlease don't do anything else and send a screenshot\nof the board as well as the following error message:\n";
                ErrorLabel.Content = errorString + error.Message + error.StackTrace;
            }
        }

        //Moves the piece to the selected destination
        private void DestinationSelected(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Image selected = (Image)sender;
                int destX = Grid.GetColumn(selected);
                int destY = 7 - Grid.GetRow(selected);
                board.movePiece(selectedSpace.x, selectedSpace.y, destX, destY);
                selectedSpace = null;
                validSpaceGrid.Children.Clear();
                updateBoard();
            }
            catch (Exception error)
            {
                String errorString = "Oopsie woopsie! Tom made a mistake!\nPlease don't do anything else and send a screenshot\nof the board as well as the following error message:\n";
                ErrorLabel.Content = errorString + error.Message + error.StackTrace;
            }
            
        }

        private void updateBoard()
        {
            pieceGrid.Children.Clear();

            foreach (Piece piece in board.getAllPieces()){

                Image image = new Image();
                image.Width = 60;
                image.Height = 60;
                BitmapImage temp = new BitmapImage();
                temp.BeginInit();
                temp.UriSource = new Uri(piece.ImagePath(), UriKind.RelativeOrAbsolute);
                temp.EndInit();
                image.Source = temp;
                image.MouseUp += PieceSelected;

                Grid.SetColumn(image, piece.x);
                Grid.SetRow(image, 7 - piece.y);
                pieceGrid.Children.Add(image);
            }
            Player1CheckLabel.Content = (board.player1Check) ? "White is in check!" : "";
            Player2CheckLabel.Content = (board.player2Check) ? "Black is in check!" : "";
            if (board.gameOver)
            {
                String winner = (board.winner == Player.Player1) ? "White" : "Black";
                MessageBox.Show("Game Over!\nWinner: " + winner);
                this.Close();
                return;
            }
            TurnLabel.Content = (board.whosTurn() == Player.Player1) ? "Turn: White" : "Turn: Black";
            TurnLabel.Foreground = (board.whosTurn() == Player.Player1) ? new SolidColorBrush(Colors.Beige) : new SolidColorBrush(Colors.Brown);

            if (board.promotionTarget != null)
            {
                this.Hide();
                new PromotionWindow(board.whosTurn(), this).Show();
            }

        }

        public void promote(PieceType piece)
        {
            switch (piece)
            {
                case PieceType.Rook:
                    board.setSpace(board.promotionTarget.x, board.promotionTarget.y, new Rook(board.promotionTarget.x, board.promotionTarget.y, board.whosTurn()));
                    break;
                case PieceType.Queen:
                    board.setSpace(board.promotionTarget.x, board.promotionTarget.y, new Queen(board.promotionTarget.x, board.promotionTarget.y, board.whosTurn()));
                    break;
                case PieceType.Bishop:
                    board.setSpace(board.promotionTarget.x, board.promotionTarget.y, new Bishop(board.promotionTarget.x, board.promotionTarget.y, board.whosTurn()));
                    break;
                case PieceType.Knight:
                    board.setSpace(board.promotionTarget.x, board.promotionTarget.y, new Knight(board.promotionTarget.x, board.promotionTarget.y, board.whosTurn()));
                    break;
            }

            board.endOfTurn();
            board.promotionTarget = null;
            this.Show();
            this.updateBoard();
   
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}
