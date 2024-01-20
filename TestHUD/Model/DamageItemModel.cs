using System.ComponentModel;

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
