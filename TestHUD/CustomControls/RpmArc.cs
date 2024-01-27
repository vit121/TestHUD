using System.Windows.Media;
using System.Windows;

namespace TestHUD.CustomControls
{
    class RpmArc : FrameworkElement
    {
        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(RpmArc), new FrameworkPropertyMetadata(90.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public double TargetAngle
        {
            get { return (double)GetValue(TargetAngleProperty); }
            set { SetValue(TargetAngleProperty, value); }
        }

        public static readonly DependencyProperty TargetAngleProperty =
            DependencyProperty.Register("TargetAngle", typeof(double), typeof(RpmArc),
                new FrameworkPropertyMetadata(300.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(Point), typeof(RpmArc), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsRender));

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(RpmArc), new FrameworkPropertyMetadata(40.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(RpmArc), new FrameworkPropertyMetadata((Brush)Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

        public double Border
        {
            get { return (double)GetValue(BorderProperty); }
            set { SetValue(BorderProperty, value); }
        }

        public static readonly DependencyProperty BorderProperty =
            DependencyProperty.Register("Border", typeof(double), typeof(RpmArc), new FrameworkPropertyMetadata((double)10, FrameworkPropertyMetadataOptions.AffectsRender));

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            DrawArc(drawingContext);
        }

        // Имеем центр, угол, радиус - возвращаем координаты
        private Point PolarToCartesian(Point center, double angle, double radius)
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
            Point startPoint = PolarToCartesian(Center, StartAngle, Radius);
            Point endPoint = PolarToCartesian(Center, StartAngle + TargetAngle, Radius);
            Size size = new(Radius, Radius);

            bool isLarge = TargetAngle > 180;

            List<PathSegment> segments = new List<PathSegment>(1);
            segments.Add(new ArcSegment(endPoint, size, 0.0, isLarge, SweepDirection.Clockwise, true)); // рисуем только по часовой

            List<PathFigure> figures = new List<PathFigure>(1);
            PathFigure pf = new PathFigure(startPoint, segments, true);
            pf.IsClosed = false;
            figures.Add(pf);
            Geometry geometry = new PathGeometry(figures, FillRule.EvenOdd, null);

            drawingContext.DrawGeometry(null, new Pen(Color, Border), geometry);
        }
    }
}
