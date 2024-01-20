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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            secondsTimer.Start();

            //CompositionTarget.Rendering += RenderFrame;
        }

        private void RenderFrame(object? sender, EventArgs e)
        {
            if (Compass.CourseAngle >= 360)
            {
                Compass.CourseAngle = 0;
            }
            if (Compass.TowerAngle >= 360)
            {
                Compass.TowerAngle = 0;
            }
            if (Speed.Speed >= 120)
            {
                Speed.Speed = 0;
            }
            if (Rpm.RpmLevel >= 100)
            {
                Rpm.RpmLevel = 25;
            }
            Compass.CourseAngle = Compass.CourseAngle + 0.5;
            Compass.TowerAngle = Compass.TowerAngle + 0.75;
            Speed.Speed = Speed.Speed + 0.4;
            Rpm.RpmLevel = Rpm.RpmLevel + 0.5;
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
