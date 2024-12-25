using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    internal class Box
    {
        int row
        {
            get;
            set;
        }
        int column { get; set; }
        public int Synbol
        {
            get { return synbol; }
            set
            {
                if (value == 1)
                {
                    synbol = 'O';
                }
                if (value == -1)
                {
                    synbol = 'X';
                }
            }
        }
        private char synbol;
        public Box(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        public void BoxChange(int a)
        {
            Synbol = a;
        }
        public char BoxRet()
        {
            return synbol;
        }
        public override string ToString()
        {
            return Convert.ToString(synbol);
        }
        public int RetInt()
        {
            if (synbol != null)
            {
                if (synbol == 'O')
                {
                    return 1;
                }
                if (synbol == 'X')
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
