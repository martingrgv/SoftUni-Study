namespace Shapes;
public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        Radius = radius;   
    }

    public double Radius 
    { 
        get { return radius; } 
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Radius cannot be zero or negative!");
            }

            radius = value;
        }
    }

    public override double CalculateArea() => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);

    public override double CalculatePerimeter() => Math.Round(2 * Math.PI * Radius, 2);

    public override string Draw()
    {
        return base.Draw();
             //+ Environment.NewLine
             //+ "Area: " + CalculateArea()
             //+ Environment.NewLine
             //+ "Perimeter: " + CalculatePerimeter();
    }
}
