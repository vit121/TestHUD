using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using TestHUD.Model;
using static System.Net.Mime.MediaTypeNames;

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

        DispatcherTimer dispatcherTimer;

        public MainWindowViewModel()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;


            Compass = new CompassModel();
            Compass.CourseAngle = 0;
            Compass.TowerAngle = 0;

            Compass.RotationPeriod = new Duration(timeSpan: new TimeSpan(0, 0, 10)); // 10 - 15 sec
            Compass.RotationAmplitude = 180; // 180 - 720

            Speed = new SpeedModel();
            Speed.Speed = 60;

            Rpm = new RpmModel();
            Rpm.IgnitionIsOn = true;

            //dispatcherTimer.Start();

            //CompositionTarget.Rendering += UpdateData;

            //Thread thread = new Thread(SinusoidalWave);
            //thread.IsBackground = true;
            //thread.Start();
        }

        private void SinusoidalWave()
        {
            //int sampleRate = 8000;
            //short[] buffer = new short[8000];
            //double amplitude = 0.25 * short.MaxValue;
            //double frequency = 1000;
            //for (int n = 0; n < buffer.Length; n++)
            //{
            //    buffer[n] = (short)(amplitude * Math.Sin((2 * Math.PI * n * frequency) / sampleRate));
            //}

            bool isAnimating = true;
            while (isAnimating) {
                double degrees = 90;
                double radians = degrees * Math.PI / 180;
                double sine = Math.Sin(radians);
                Console.WriteLine("The sine of " + degrees + " degrees is: " + sine);

                if (Compass.CourseAngle >= 360)
                {
                    Compass.CourseAngle = 0;
                }
                Compass.CourseAngle = Compass.CourseAngle + 1;
                Thread.Sleep(1000);
            }
        }

        private void UpdateData(object? sender, EventArgs e)
        {
            Debug.WriteLine("UpdateData()");
            if (Compass.CourseAngle >= 360)
            {
                Compass.CourseAngle = 0;
            }
            Compass.CourseAngle = Compass.CourseAngle + 1;
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            Compass.CourseAngle = Compass.CourseAngle + 1;
            Compass.TowerAngle = Compass.TowerAngle - 1;
            OnPropertyChanged("CourseAngle");
        }


        #region
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
