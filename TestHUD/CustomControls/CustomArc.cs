using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using TestHUD.Helpers;

namespace TestHUD.CustomControls
{
    class CustomArc : FrameworkElement
    {
        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(CustomArc), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public double TargetAngle
        {
            get { return (double)GetValue(TargetAngleProperty); }
            set { SetValue(TargetAngleProperty, value); }
        }

        public static readonly DependencyProperty TargetAngleProperty =
            DependencyProperty.Register("TargetAngle", typeof(double), typeof(CustomArc),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(Point), typeof(CustomArc), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsRender));

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(CustomArc), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(CustomArc), new FrameworkPropertyMetadata((Brush)Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CustomArc), new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.AffectsRender));

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            DrawArc(drawingContext);
        }

        private Point PolarToCartesian(double angle, double radius, Point center)
        {
            double pointX = (center.X + (radius * Math.Cos(DegreesToRadian(angle))));
            double pointY = (center.Y + (radius * Math.Sin(DegreesToRadian(angle))));
            return new Point(pointX, pointY);
        }

        private double DegreesToRadian(double degrees) // Radian to degrees: radian * 180 / Math.PI;
        {
            return degrees * (Math.PI / 180);
        }

        private void DrawArc(DrawingContext drawingContext)
        {
            Point startPoint = PolarToCartesian(StartAngle, Radius, Center);
            Point endPoint = PolarToCartesian(StartAngle + TargetAngle, Radius, Center);
            Size size = new(Radius, Radius);

            bool isLarge = TargetAngle > 180;
            //Debug.WriteLine("isLarge: " + isLarge + " " + TargetAngle);

            List<PathSegment> segments = new List<PathSegment>(1);
            segments.Add(new ArcSegment(endPoint, size, 0.0, isLarge, SweepDirection.Clockwise, true));

            List<PathFigure> figures = new List<PathFigure>(1);
            PathFigure pf = new PathFigure(startPoint, segments, true);
            pf.IsClosed = false;
            figures.Add(pf);
            Geometry geometry = new PathGeometry(figures, FillRule.EvenOdd, null);

            drawingContext.DrawGeometry(null, new Pen(Color, StrokeThickness), geometry);
        }
    }
}
