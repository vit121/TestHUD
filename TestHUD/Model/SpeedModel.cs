using System.ComponentModel;

namespace TestHUD.Model
{
    public class SpeedModel: INotifyPropertyChanged
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

        private double speed;
        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                NotifyPropertyChanged("Speed");
            }
        }

        public string SpeedUnits { get; set; } = "км/ч";

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
