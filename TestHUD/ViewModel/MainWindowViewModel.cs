using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestHUD.Model;

namespace TestHUD.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CompassModel compass;
        public CompassModel Compass
        {
            get { return compass; }
            set
            {
                compass = value;
                OnPropertyChanged("Compass");
            }
        }

        public MainWindowViewModel()
        {
            Compass = new CompassModel();
            Compass.CourseAngle = 270;
            Compass.TowerAngle = 30;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
