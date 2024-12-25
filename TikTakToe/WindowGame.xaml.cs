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
    /// Логика взаимодействия для WindowGame.xaml
    /// </summary>
    public partial class WindowGame : Window
    {
        public WindowGame()
        {
            InitializeComponent();
            buttons = new List<Button> { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            CPU = 0;

        }
        public WindowGame(int a)
        {
            InitializeComponent();
            buttons = new List<Button> { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            CPU = 1;
        }
        List<Button> buttons;
        Box[,] box =
                    {
                { new Box(1, 1), new Box(1, 2), new Box(1, 3) },
                { new Box(2, 1), new Box(2, 2), new Box(2, 3) },
                { new Box(3, 1), new Box(3, 2), new Box(3, 3) }
            };
        int CPU = 0;
        int player = 1;
        bool Contineu = true;
        int turnNumber = 0;
        Brush[] colour = { Brushes.Salmon,  Brushes.Yellow, Brushes.Blue};
        string[] winers = { "Красный", "Компьютер", "Синий" };
        public void Press(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int y = Grid.GetColumn(button) - 1;
            int x = Grid.GetRow(button) - 1;
            box[x, y].BoxChange(player);
            button.Content = box[x, y].BoxRet();
            buttons.Remove(button);
            button.IsEnabled = false;
            button.Foreground = colour[player + (player * player)];
            turnNumber++;
            if (turnNumber > 4 & Contineu)
            {
                if (Check() == true)
                {
                    Contineu = false;
                    if (player == 1) { CPU = 0; }
                    string winer = winers[player + (player * player) + CPU];
                    NameInput input = new NameInput(winer);
                    input.Password = winer;
                    if (winer == "Компьютер") 
                    {   
                        input.passwordBox.IsEnabled = false;
                        input.OK_BUTT.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        input.OK_BUTT.IsEnabled = false;
                    }
                    if (input.ShowDialog() == true)
                    {
                        winer = input.Password;
                    }                 
                    MessageBox.Show($"Победитель {winer}");
                    MainWindow a = new MainWindow();
                    a.Show();
                    this.Close();
                }
            }
            ScoreText.Text = turnNumber.ToString();
            player = player * -1;
            if (turnNumber == 9 & Contineu)
            {
                Contineu = false;
                MessageBox.Show("Ничья!");
                MainWindow a = new MainWindow();
                a.Show();
                this.Close();
            }
            if (CPU == 1 & turnNumber % 2 != 0 & Contineu)
            {
                Random random = new Random();
                Button but = buttons[random.Next(buttons.Count - 1)];
                but.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        public bool Check()
        {
            int chek;
            int chek2;
            for (int i = 0; i < 3; i++)
            {
                chek = 0;
                chek2 = 0;
                for (int ii = 0; ii < 3; ii++)
                {
                    chek = chek + box[i, ii].RetInt();
                    chek2 = chek2 + box[ii, i].RetInt();
                }
                if (chek == 3 || chek2 == 3)
                {
                    return true;
                }
                if (chek == -3 || chek2 == -3)
                {
                    return true;
                }
            }
            if (box[0, 0].BoxRet() == box[1, 1].BoxRet() && box[1, 1].BoxRet() == box[2, 2].BoxRet())
            {
                return true;
            }
            if (box[0, 2].BoxRet() == box[1, 1].BoxRet() && box[1, 1].BoxRet() == box[2, 0].BoxRet())
            {
                return true;
            }
            return false;
        }

    }
}
