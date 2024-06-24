namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double @base = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double answ = Pow(@base, power);

            Console.WriteLine(answ);
        }

        static double Pow(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}