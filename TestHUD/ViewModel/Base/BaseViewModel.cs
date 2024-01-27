using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestHUD.ViewModel.Base
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
