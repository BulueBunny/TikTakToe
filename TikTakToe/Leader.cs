using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace TikTakToe
{
    [PrimaryKey(nameof(Name))]
    public class Leader : INotifyPropertyChanged
    {
        
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        private string name;
        private static int ID {  get; set; }
        public int Wins { get { return wins; } set { wins = value; OnPropertyChanged("Wins"); } }
        private int wins;
        public Leader(string name)
        {
            Name = name;
            Wins = 1;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
