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

        public MainWindowViewModel()
        {
            Compass = new CompassModel();
            Speed = new SpeedModel();
            Rpm = new RpmModel();
            Damages = new DamagesModel();

            #region Animation: Compass. Angle and Tower
            AnimationService animation_Compass_CourseAngle = new AnimationService();
            animation_Compass_CourseAngle.TargetModified += (target) =>
            {
                Compass.CourseAngle = target;
            };
            // Данные: вращение в одну сторону 0.5 оборота 10 секунд, в другую - 2 полных оборота 15 секунд
            animation_Compass_CourseAngle.StartAnimationAsync(from: 0, to: 180, periodForward: 10, periodBack: 15, targetCustomCompassPosition: -720);

            AnimationService animation_Compass_CourseTower = new AnimationService();
            animation_Compass_CourseTower.TargetModified += (target) =>
            {
                Compass.TowerAngle = target;
            };
            // Данные: вращение в одну сторону 45 градусов 8 секунд, в другую - 90 градусов 20 секунд
            animation_Compass_CourseTower.StartAnimationAsync(from: 0, to: 45, periodForward: 8, periodBack: 20, targetCustomCompassPosition: -90);
            #endregion

            #region Animation: Speed
            AnimationService animation_Speed = new AnimationService();
            animation_Speed.TargetModified += (target) =>
            {
                Speed.Speed = target;
            };
            // Данные: набор скорости до 120 в течение 5 секунд, сброс до 0 в течение 10 секунд
            animation_Speed.StartAnimationAsync(from: 0, to: 120, periodForward: 5, periodBack: 10);
            #endregion

            #region Animation: Rpm
            AnimationService animation_RpmLevel = new AnimationService();
            animation_RpmLevel.TargetModified += (target) =>
            {
                Rpm.RpmLevel = target;
            };
            // Данные: набор оборотов от 25 до 100 в течение 5 секунд, сброс до 25 в течение 10 секунд
            animation_RpmLevel.StartAnimationAsync(from: 25, to: 100, periodForward: 5, periodBack: 10);
            #endregion

            #region Timer imitation: Damages and Rpm ignition indicator
            DamagesAndIgnitionSerivce animation_DamagesAndIgnition = new DamagesAndIgnitionSerivce();
            animation_DamagesAndIgnition.TargetModified += (isTrue, damageId) =>
            {
                Rpm.IgnitionIsOn = isTrue;
                Damages.GetDamageItemFromId(damageId).IsDamaged = isTrue;
            };
            animation_DamagesAndIgnition.StartImitation();
            #endregion
        }
    }
}
