using System.Security.Cryptography;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fNum = int.Parse(Console.ReadLine());
            int lNum = int.Parse(Console.ReadLine());

            double fFactorial = GetFactorial(fNum);
            double lFactorial = GetFactorial(lNum);

            double result = fFactorial / lFactorial;

            Console.WriteLine($"{result:f2}");
        }

        static double GetFactorial(double num)
        {
            double factorial = 1;

            for (int i = 2; i <= num; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
    }
}