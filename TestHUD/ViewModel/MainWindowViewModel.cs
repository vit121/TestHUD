using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestHUD.Model;

namespace TestHUD.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CompassModel compass;
        public CompassModel Compass
        {
            get { return compass; }
            set {
                compass = value;
                OnPropertyChanged("Compass");
            }
        }

        public MainWindowViewModel()
        {
            Compass = NewMethod();
            Compass.CourseAngle = 100;
            Compass.TowerAngle = 90;

            Compass.RotationPeriod = new Duration(timeSpan: new TimeSpan(0, 0, 10)); // 10 - 15 sec
            Compass.RotationAmplitude = -360; // 180 - 720
        }

        private static CompassModel NewMethod()
        {
            return new CompassModel();
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
