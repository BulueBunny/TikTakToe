using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TikTakToe
{
    /// <summary>
    /// Логика взаимодействия для NameInput.xaml
    /// </summary>
    public partial class NameInput : Window
    {
        
        public NameInput(string Name)
        {
            LeaderMV leaderMV = new LeaderMV();
            InitializeComponent();
            DataContext = leaderMV;
            leaderMV.Leder = new Leader(Name);
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Password != "Красный" && Password != "Синий") { this.DialogResult = true; }
            else { this.DialogResult = false; }
        }

        public string Password
        {
            get { return passwordBox.Text; }
            set { passwordBox.Text = value; }
        }
    }
}
