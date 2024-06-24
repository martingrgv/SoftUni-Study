namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double area = GetRectangleArea(a, b);

            Console.WriteLine(area);
        }

        static double GetRectangleArea(double a, double b)
        {
            return a * b;
        }
    }
}