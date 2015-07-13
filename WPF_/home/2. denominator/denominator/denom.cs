using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denominator 
{
    public class denom : INotifyPropertyChanged
    {
        private String hundred;
        public String Hundred
        {
            set
            {
                if (hundred != value)
                {
                    hundred = value;
                    OnPropertyChanged("Hundred");
                    OnPropertyChanged("Total");
                }
            }
            get { return hundred; }
        }

        private String fifty;
        public String Fifty
        {
            set
            {
                if (fifty != value)
                {
                    fifty = value;
                    OnPropertyChanged("Fifty");
                    OnPropertyChanged("Total");
                }
            }
            get { return fifty; }
        }

        private String twentyfifty;
        public String Twentyfifty
        {
            set
            {
                if (twentyfifty != value)
                {
                    twentyfifty = value;
                    OnPropertyChanged("twentyfifty");
                    OnPropertyChanged("Total");
                }
            }
            get { return twentyfifty; }
        }

        private String ten;
        public String Ten
        {
            set
            {
                if (ten != value)
                {
                    ten = value;
                    OnPropertyChanged("Ten");
                    OnPropertyChanged("Total");
                }
            }
            get { return ten; }
        }

        private String f;
        public String  F
        {
            set
            {
                if (f != value)
                {
                    f = value;
                    OnPropertyChanged("F");
                    OnPropertyChanged("Total");
                }
            }
            get { return f; }
        }


        private String total;   
        public String Total
        {
            get { return (Convert.ToInt32(Hundred) * 100 + Convert.ToInt32(Fifty)*50 +Convert.ToInt32(Twentyfifty)*25 + Convert.ToInt32(Ten)*10+Convert.ToInt32(F)*5).ToString(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string total)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(total));
            }
        }


    }
}
