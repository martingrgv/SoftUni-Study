namespace _11.RefractorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Console.Write("Length: ");
            Console.Write("Width: ");
            Console.Write("Height: ");

            double vol = (l * w * h) / 3;
            Console.Write($"Pyramid Volume: {vol:f2}");
        }
    }
}