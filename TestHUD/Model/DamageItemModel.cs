using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestHUD.Model
{
    public class DamageItemModel: INotifyPropertyChanged
    {
        public int DamageId { get; set; }

        private bool isDamaged;
        public bool IsDamaged
        {
            get { return isDamaged; }
            set
            {
                isDamaged = value;
                NotifyPropertyChanged("IsDamaged");
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
