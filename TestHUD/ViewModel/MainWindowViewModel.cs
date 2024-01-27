using System.Windows.Threading;
using TestHUD.Model;
using TestHUD.Services;
using TestHUD.ViewModel.Base;

namespace TestHUD.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public CompassModel Compass { get; set; }
        public SpeedModel Speed { get; set; }
        public RpmModel Rpm { get; set; }
        public DamagesModel Damages { get; set; }

        DispatcherTimer secondsTimer;
        Random random = new Random();
        int[] damageItemNumbers = [1, 2, 3, 4, 5];

        public MainWindowViewModel()
        {
            Compass = new CompassModel();
            Speed = new SpeedModel();
            Rpm = new RpmModel();
            Damages = new DamagesModel();

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

            // Animation: Damages and Rpm ignition flag
            secondsTimer = new DispatcherTimer();
            secondsTimer.Interval = new TimeSpan(0, 0, 1);
            secondsTimer.Tick += secondsTimer_Tick;
            secondsTimer.Start();
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
            Damages.GetDamageItemFromId(randomNumber).IsDamaged = randomBool; // random damage item
        }
        #endregion
    }
}
