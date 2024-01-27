using TestHUD.Helpers;
using TestHUD.Model.Base;

namespace TestHUD.Model
{
    public class RpmModel: BaseModel
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

        private double rpmLevel;
        public double RpmLevel
        {
            get { return rpmLevel; }
            set
            {
                rpmLevel = value;
                NotifyPropertyChanged("RpmLevel");
            }
        }

        private bool ignitionIsOn;
        public bool IgnitionIsOn
        {
            get { return ignitionIsOn; }
            set
            {
                ignitionIsOn = value;
                NotifyPropertyChanged("IgnitionIsOn");
            }
        }

        public string RpmUnits { get; set; }

        public RpmModel()
        {
            IsVisible = true;
            RpmUnits = Constants.UnitsRpm;
        }
    }
}
