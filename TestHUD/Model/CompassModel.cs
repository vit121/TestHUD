using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestHUD.Model
{
    public class CompassModel
    {
        public bool IsAnimating { get; set; }

        public int CourseAngle { get; set; }

        public int TowerAngle { get; set; }

        public Duration RotationPeriod { get; set;}

        public double RotationAmplitude { get; set; }
    }
}
