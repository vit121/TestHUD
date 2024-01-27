using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Media;
using System.Windows.Threading;
using TestHUD.Model;
using TestHUD.Services;
using TestHUD.ViewModel.Base;

namespace TestHUD.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        public CompassModel Compass { get; set; }
        public SpeedModel Speed { get; set; }
        public RpmModel Rpm { get; set; }
        // Damages
        private bool isVisible_Damages;
        public bool IsVisible_Damages
        {
            get { return isVisible_Damages; }
            set
            {
                isVisible_Damages = value;
                OnPropertyChanged("IsVisible_Damages");
            }
        }
        public DamageItemModel DamageItem_EngineOverheat { get; set; }
        public DamageItemModel DamageItem_OilLowPressure { get; set; }
        public DamageItemModel DamageItem_EngineDamaged { get; set; }
        public DamageItemModel DamageItem_HeadLightsOn { get; set; }
        public DamageItemModel DamageItem_AccumLowPower { get; set; }
        #endregion

        DispatcherTimer secondsTimer;
        Random random = new Random();
        int[] damageItemNumbers = [1, 2, 3, 4, 5];

        public MainWindowViewModel()
        {
            secondsTimer = new DispatcherTimer();
            secondsTimer.Interval = new TimeSpan(0, 0, 1);
            secondsTimer.Tick += secondsTimer_Tick;

            Compass = new CompassModel
            {
                IsVisible = true
            };

            Speed = new SpeedModel
            {
                IsVisible = true
            };

            Rpm = new RpmModel()
            {
                IsVisible = true,
                RpmLevel = 0
            };

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
            isVisible_Damages = true;

            secondsTimer.Start();

            // Animation: Compass. Angle
            AnimationService animation_Compass_CourseAngle = new AnimationService();
            animation_Compass_CourseAngle.TargetModified += (target) =>
            {
                Compass.CourseAngle = target;
            };
            animation_Compass_CourseAngle.StartAnimationAsync(from: 0, to: 180, periodForward: 10, periodBack: 15, targetCustomCompassPosition: -720);

            // Animation: Compass. Tower
            AnimationService animation_Compass_CourseTower = new AnimationService();
            animation_Compass_CourseTower.TargetModified += (target) =>
            {
                Compass.TowerAngle = target;
            };
            animation_Compass_CourseTower.StartAnimationAsync(from: 0, to: 45, periodForward: 8, periodBack: 20, targetCustomCompassPosition: -90);

            // Animation: Speed
            AnimationService animation_Speed = new AnimationService();
            animation_Speed.TargetModified += (target) =>
            {
                Speed.Speed = target;
            };
            animation_Speed.StartAnimationAsync(from: 0, to: 120, periodForward: 5, periodBack: 10);

            // Animation: Rpm
            AnimationService animation_RpmLevel = new AnimationService();
            animation_RpmLevel.TargetModified += (target) =>
            {
                Rpm.RpmLevel = target;
            };
            animation_RpmLevel.StartAnimationAsync(from: 25, to: 100, periodForward: 5, periodBack: 10);
        }

        #region Damages
        private void secondsTimer_Tick(object? sender, EventArgs e)
        {
            ImitateTimerData();
        }

        private void ImitateTimerData()
        {
            bool randomBool = random.Next(2) == 1;
            // Rpm ignition
            Rpm.IgnitionIsOn = randomBool; // random turning on/off
            // Damages
            int randomIndex = random.Next(0, 5);
            int randomNumber = damageItemNumbers[randomIndex];
            GetDamageItemFromId(randomNumber).IsDamaged = randomBool; // random damage item
        }

        private DamageItemModel GetDamageItemFromId(int damageItemId)
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
        #endregion
    }
}
