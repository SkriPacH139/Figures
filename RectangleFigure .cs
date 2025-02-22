namespace Figures
{
    public class RectangleFigure : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public RectangleFigure(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
    }
}
