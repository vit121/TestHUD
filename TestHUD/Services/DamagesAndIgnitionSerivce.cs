using System.Windows.Threading;

namespace TestHUD.Services
{
    public class DamagesAndIgnitionSerivce
    {
        public event Action<bool, int>? TargetModified;

        DispatcherTimer secondsTimer;
        Random random = new Random();
        int[] damageItemNumbers = [1, 2, 3, 4, 5];

        public DamagesAndIgnitionSerivce()
        {
            secondsTimer = new DispatcherTimer();
            secondsTimer.Interval = new TimeSpan(0, 0, 1);
            secondsTimer.Tick += secondsTimer_Tick;
        }

        public void StartImitation()
        {
            secondsTimer.Start();
        }

        public void StopImitation()
        {
            secondsTimer.Stop();
        }

        private void secondsTimer_Tick(object? sender, EventArgs e)
        {
            ImitateTimerData();
        }

        private void ImitateTimerData()
        {
            bool randomBool = random.Next(2) == 1;
            int randomIndex = random.Next(0, 5);
            int damageId = damageItemNumbers[randomIndex];
            TargetModified?.Invoke(randomBool, damageId);
        }
    }
}
