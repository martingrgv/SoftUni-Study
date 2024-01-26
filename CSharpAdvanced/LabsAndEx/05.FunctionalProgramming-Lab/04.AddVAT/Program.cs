namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = (double x) => x + x * 0.2;

            double[] numbers = Console.ReadLine()
                            .Split(", ",
                             StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .Select(n => addVat(n))
                            .ToArray();

            Action<double> print = n => Console.WriteLine($"{n:f2}");

            for (int i = 0; i < numbers.Length; i++)
                print(numbers[i]);
        }
    }
}
