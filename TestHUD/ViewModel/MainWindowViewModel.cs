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

        private SpeedModel speed;
        public SpeedModel Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        private RpmModel rpm;
        public RpmModel Rpm
        {
            get { return rpm; }
            set
            {
                rpm = value;
                OnPropertyChanged("Rpm");
            }
        }

        public MainWindowViewModel()
        {
            Compass = new CompassModel();
            Compass.CourseAngle = 90;
            Compass.TowerAngle = 47;

            Compass.RotationPeriod = new Duration(timeSpan: new TimeSpan(0, 0, 10)); // 10 - 15 sec
            Compass.RotationAmplitude = -360; // 180 - 720

            Speed = new SpeedModel();
            Speed.Speed = 60;

            Rpm = new RpmModel();
            Rpm.IgnitionIsOn = true;
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
