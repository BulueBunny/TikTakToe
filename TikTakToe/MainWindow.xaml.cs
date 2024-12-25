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

namespace TikTakToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            GridMain.DataContext = this;
        }
        public void Start(object sender, RoutedEventArgs e)
        {
            Button a = sender as Button;
            WindowGame gameWindow;
            if (Grid.GetRow(a) == 7)
            {
                gameWindow = new WindowGame();
            }
            else
            {
                gameWindow = new WindowGame(1);
            }
            gameWindow.Show();
            this.Close();
        }
        public void Leader(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.Show();
            this.Close();
        }
    }
}
