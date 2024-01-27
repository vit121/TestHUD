using System.Reflection.Metadata;
using TestHUD.Helpers;
using TestHUD.Model.Base;

namespace TestHUD.Model
{
    public class SpeedModel: BaseModel
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

        public string SpeedUnits { get; set; }

        public SpeedModel()
        {
            IsVisible = true;
            SpeedUnits = Constants.UnitsSpeed;
        }
    }
}
