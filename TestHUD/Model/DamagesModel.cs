using TestHUD.Model.Base;

namespace TestHUD.Model
{
    public class DamagesModel: BaseModel
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

        public DamageItemModel DamageItem_EngineOverheat { get ;set; }
        public DamageItemModel DamageItem_OilLowPressure { get; set; }
        public DamageItemModel DamageItem_EngineDamaged { get; set; }
        public DamageItemModel DamageItem_HeadLightsOn { get; set; }
        public DamageItemModel DamageItem_AccumLowPower { get; set; }

        public DamagesModel()
        {
            IsVisible = true;
            DamageItem_EngineOverheat = new DamageItemModel()
            {
                DamageId = 1
            };
            DamageItem_OilLowPressure = new DamageItemModel()
            {
                DamageId = 2
            };
            DamageItem_EngineDamaged = new DamageItemModel()
            {
                DamageId = 3
            };
            DamageItem_HeadLightsOn = new DamageItemModel()
            {
                DamageId = 4
            };
            DamageItem_AccumLowPower = new DamageItemModel()
            {
                DamageId = 5
            };
        }

        public DamageItemModel GetDamageItemFromId(int damageItemId)
        {
            switch (damageItemId)
            {
                default:
                    throw new NotImplementedException();
                case 1:
                    return DamageItem_EngineOverheat;
                case 2:
                    return DamageItem_OilLowPressure;
                case 3:
                    return DamageItem_EngineDamaged;
                case 4:
                    return DamageItem_HeadLightsOn;
                case 5:
                    return DamageItem_AccumLowPower;
            }
        }
    }
}
