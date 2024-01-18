using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestHUD.Model
{
    public class CompassModel: INotifyPropertyChanged
    {
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                NotifyPropertyChanged("IsVisible");
            }
        }

        public bool IsAnimating { get; set; }

        private double courseAngle;
        public double CourseAngle
        {
            get { return courseAngle; }
            set
            {
                courseAngle = value; 
                NotifyPropertyChanged("CourseAngle");
            }
        }
        public double TowerAngle { get; set; }

        public Duration RotationPeriod { get; set;}

        public double RotationAmplitude { get; set; }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
