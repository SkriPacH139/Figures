namespace Figures
{
    public class TriangleFigure : Figure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public TriangleFigure(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetArea()
        {
            double p = (SideA + SideB + SideC) / 2.0;
            return System.Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
    }
}
