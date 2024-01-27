using TestHUD.Model.Base;

namespace TestHUD.Model
{
    public class CompassModel: BaseModel
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

        public CompassModel()
        {
            IsVisible = true;
        }
    }
}
