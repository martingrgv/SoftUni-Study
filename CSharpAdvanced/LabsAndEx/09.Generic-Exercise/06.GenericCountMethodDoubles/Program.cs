using GenericBox;

namespace _06.GenericCountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < lines; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            double compareElement = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountGreaterThan(compareElement));
        }
    }
}
