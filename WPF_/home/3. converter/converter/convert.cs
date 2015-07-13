using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace converter
{
    public class convert : IValueConverter
    {
        private String _hrn;
        private String _dol;

        public String Hrn
        {
            set
            {
                if (_hrn != value)
                {
                    _hrn = value;
          
                }
            }
            get { 
                
                return _hrn;
                
            }
        }

        public String Dol
        {
            set
            {
                if (_dol != value)
                {
                    _dol = value;
           
                }
            }
            get { return _dol; }
        }



        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          //  throw new NotImplementedException();

            return (Convert.ToInt32(Hrn) * 100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
