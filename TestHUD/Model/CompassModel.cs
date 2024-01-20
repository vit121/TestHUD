using System.ComponentModel;

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

        private double towerAngle;
        public double TowerAngle
        {
            get { return towerAngle; }
            set
            {
                towerAngle = value;
                NotifyPropertyChanged("TowerAngle");
            }
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
