using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TikTakToe
{
    internal class LeaderMV : INotifyPropertyChanged
    {
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        private string name;
        public int Wins { get { return wins; } set { wins = value; OnPropertyChanged("Wins"); } }
        private int wins;
        private Leader leader;
        public Leader Leder { get { return leader; } set { leader = value; OnPropertyChanged("Leder"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Leader> LeaderList { get; set; } = new ObservableCollection<Leader>();
        private ApplicationContext _context = new ApplicationContext();

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public LeaderMV()
        {
            _context.Database.EnsureCreated();
            _context.Leaders.Load();
            LeaderList = _context.Leaders.Local.ToObservableCollection();
        }
        private RelayCommand addLeaderToList;
        private RelayCommand removeLeaderFromList;
        private RelayCommand updateLeaderFromList;
        public RelayCommand AddLeaderToList
        {
            get
            {

                return addLeaderToList ??
                   (addLeaderToList = new RelayCommand(obj =>
                   {
                       _context.Leaders.Add(Leder);
                       _context.SaveChanges();
                   }));
            }
        }
        public RelayCommand UpdateLeaderFromList
        {
            get
            {
                return updateLeaderFromList ??
                    (updateLeaderFromList = new RelayCommand(obj =>
                    {
                        Name = Leder.Name;
                        string sqlExpression = $"UPDATE Leaders SET Wins=Wins+1 WHERE Name='{Name}'";
                        using (var connection = new SqliteConnection("Data Source=LeadersDB.db"))
                        {
                            connection.Open();

                            SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                            int number = command.ExecuteNonQuery();
                            if (number == 0)
                            {
                                _context.Leaders.Add(Leder);
                                _context.SaveChanges();
                            }
                        }
                    }));
            }
        }
        public RelayCommand RemoveLeaderFromList
        {
            get
            {
                return removeLeaderFromList ??
                    (removeLeaderFromList = new RelayCommand(obj =>
                    {
                        Leader? leader = Leder as Leader;
                        if (leader == null) {return; }
                        _context.Leaders.Remove(leader);
                        _context.SaveChanges();
                    }));
            }
        }
    }
}
