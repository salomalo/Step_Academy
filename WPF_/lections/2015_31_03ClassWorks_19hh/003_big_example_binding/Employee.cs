using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _003_big_example_binding
{
    public class Employee : INotifyPropertyChanged
    {
        private ImageSource _photo;
        private string _name;

        public int Id { set; get; }
        public string Name 
        {
            set {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
            get { return _name; } 
        
        }
        public string Department { set; get; }
        public string JobTitle { set; get; }
        public string Phone { set; get; }
        public Uri PhotoUri { set; get; }

        public ImageSource Photo
        {
            get {
                if (_photo == null)
                {
                    _photo = DataSupplier.LoadPicture(PhotoUri);
                }

                return _photo;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
