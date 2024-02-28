namespace Shapes;
public class StartUp
{
    static void Main(string[] args)
    {
        Func<int> GetInput = () => int.Parse(Console.ReadLine());

        IDrawable circle = new Circle(GetInput());
        IDrawable rect = new Rectangle(GetInput(), GetInput());

        circle.Draw();
        rect.Draw();
    }
}

