using TestHUD.Model.Base;

namespace TestHUD.Model
{
    public class DamageItemModel: BaseModel
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
    }
}
