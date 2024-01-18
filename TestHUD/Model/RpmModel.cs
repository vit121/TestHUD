using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestHUD.Model
{
    public class RpmModel: INotifyPropertyChanged
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

        public double RpmLevel { get; set; }

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

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
