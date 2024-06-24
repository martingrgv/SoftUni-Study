namespace Shapes;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public double Height 
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative!");
            }

            height = value;
        }
    }

    public double Width 
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative!");
            }

            width = value;
        }
    }

    public override double CalculateArea() => Width * Height;

    public override double CalculatePerimeter() => 2 * (Width + Height);

    public override string Draw()
    {
        return base.Draw();
             //+ Environment.NewLine
             //+ "Area: " + CalculateArea()
             //+ Environment.NewLine
             //+ "Perimeter: " + CalculatePerimeter();
    }
}
