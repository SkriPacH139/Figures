using System;

namespace Figures
{
    public class CircleFigure : Figure
    {
        public double Radius { get; set; }

        public CircleFigure(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;        
    }
}
