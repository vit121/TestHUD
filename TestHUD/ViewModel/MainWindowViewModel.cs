using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Threading;
using TestHUD.Model;

namespace TestHUD.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
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

            //CompositionTarget.Rendering += RenderFrame;
            //TestAnimation();

            GenerateAnimation();
        }

        private async void GenerateAnimation()
        {
            await Task.Delay(1000);

            double periodMin = 5;
            double periodMax = 10;

            double amplitude = 75;
            double time = 0;
            double deltaTime = 0.1; // adjust as needed

            double amplitudeMin = 25;
            double amplitudeMax = 100;

            // Stopwatch to measure elapsed time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bool animationIsDirect = true;

            double period = periodMin;

            //while (stopwatch.Elapsed.TotalSeconds < totalTime)
            while (true)
            {
                // На выходе нам нужно получить только положительное значение sineValue, соответствующее амплитуде и периоду.
                double sineWaveMinimumPosition = amplitudeMin / 2;
                double sineWaveAmplitude = (amplitudeMax / 2) - sineWaveMinimumPosition; // Учитываем начальную позицию
                double sineWavePeriod = period * 2; // * 2 - для одного направления
                double sineWaveOffset = (amplitudeMax / 2) + sineWaveMinimumPosition; // Компенсируем дополнительный offset, вместе с начальной позицией
                double sineValue = GenerateSineWave(time, sineWaveAmplitude, sineWavePeriod) + sineWaveOffset;


                Rpm.RpmLevel = sineValue;
                Debug.WriteLine("RpmLevel: " + Rpm.RpmLevel);


                // Check if it's time to switch to the other period
                //if (animationIsDirect)
                //{
                //    if (Rpm.RpmLevel >= amplitudeMax)
                //    {
                //        animationIsDirect = false;
                //        period = periodMax;
                //    }
                //}
                //else
                //{
                //    if (Rpm.RpmLevel <= amplitudeMin)
                //    {
                //        animationIsDirect = true;
                //        period = periodMin;
                //    }
                //}

                // Check if it's time to switch to the other period
                //if (animationIsDirect)
                //if (Rpm.RpmLevel >= amplitudeMax)
                //{
                //    // Switch the period
                //    period = (period == periodMin) ? periodMax : periodMin;
                //    periodTime = 0; // Reset time for the new period
                //}



                //if (animationIsDirect)
                //{
                //    period = periodMin;
                //}
                //else
                //{
                //    period = periodMax;
                //}
                Debug.WriteLine("period: " + period);

                time += deltaTime;

                // Add a delay for smoother animation (adjust as needed)
                await Task.Delay((int)(deltaTime * 1000));
            }

            stopwatch.Stop();
        }

        private double GenerateSineWave(double x, double amplitude, double period)
        {
            // Calculate the sine wave value using the formula: y = A * sin(2 * π * x / T + φ)
            double initialPhase = -Math.Asin(1.0);
            double radianValue = 2 * Math.PI * x / period + initialPhase;
            double sineValue = amplitude * Math.Sin(radianValue);
            return sineValue;
        }

        //private static double CalculateOffset(double time, double startOffset, double endOffset)
        //{
        //    // Linearly interpolate between startOffset and endOffset based on time
        //    double normalizedTime = time % 1; // Ensure time is within one period
        //    double offsetRange = endOffset - startOffset;
        //    return startOffset + offsetRange * normalizedTime;
        //}

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

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
