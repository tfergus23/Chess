using System.Windows;


namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Chess V1.1";
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            new GameWindow(this).Show();
            this.Hide();
        }
    }
}
