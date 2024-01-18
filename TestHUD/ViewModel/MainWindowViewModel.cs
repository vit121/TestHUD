using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using TestHUD.Model;
using static System.Net.Mime.MediaTypeNames;

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

        DispatcherTimer secondTimer;
        Random random = new Random();
        int[] damageItemNumbers = new int[5] { 1, 2, 3, 4, 5 };

        public MainWindowViewModel()
        {
            secondTimer = new DispatcherTimer();
            secondTimer.Interval = new TimeSpan(0, 0, 1);
            secondTimer.Tick += secondTimer_Tick;

            Compass = new CompassModel
            {
                IsVisible = true,
                CourseAngle = 0,
                TowerAngle = 0,
                RotationPeriod = new Duration(timeSpan: new TimeSpan(0, 0, 10)), // 10 - 15 sec
                RotationAmplitude = 180 // 180 - 720
            };

            Speed = new SpeedModel
            {
                IsVisible = true,
                Speed = 60
            };

            Rpm = new RpmModel()
            {
                IsVisible = true
            };

            isVisible_Damages = true;
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


            secondTimer.Start();

            //CompositionTarget.Rendering += UpdateData;

            //Thread thread = new Thread(SinusoidalWave);
            //thread.IsBackground = true;
            //thread.Start();
        }

        private void SinusoidalWave()
        {
            //int sampleRate = 8000;
            //short[] buffer = new short[8000];
            //double amplitude = 0.25 * short.MaxValue;
            //double frequency = 1000;
            //for (int n = 0; n < buffer.Length; n++)
            //{
            //    buffer[n] = (short)(amplitude * Math.Sin((2 * Math.PI * n * frequency) / sampleRate));
            //}

            bool isAnimating = true;
            while (isAnimating) {
                double degrees = 90;
                double radians = degrees * Math.PI / 180;
                double sine = Math.Sin(radians);
                Console.WriteLine("The sine of " + degrees + " degrees is: " + sine);

                if (Compass.CourseAngle >= 360)
                {
                    Compass.CourseAngle = 0;
                }
                Compass.CourseAngle = Compass.CourseAngle + 1;
                Thread.Sleep(1000);
            }
        }

        private void UpdateData(object? sender, EventArgs e)
        {
            Debug.WriteLine("UpdateData()");
            if (Compass.CourseAngle >= 360)
            {
                Compass.CourseAngle = 0;
            }
            Compass.CourseAngle = Compass.CourseAngle + 1;
        }

        #region Damages

        private void secondTimer_Tick(object? sender, EventArgs e)
        {
            //Compass.CourseAngle = Compass.CourseAngle + 1;
            //Compass.TowerAngle = Compass.TowerAngle - 1;
            //OnPropertyChanged("CourseAngle");
            ImitateTimerData();
        }

        private void ImitateTimerData()
        {
            bool randomBool = random.Next(2) == 1;

            // Rpm ignition
            Rpm.IgnitionIsOn = randomBool; // random turning on/off
            Debug.WriteLine(Rpm.IgnitionIsOn);

            // Damages
            int randomIndex = random.Next(0, 5);
            int randomNumber = damageItemNumbers[randomIndex];
            GetDamageItemFromId(randomNumber).IsDamaged = randomBool;
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
