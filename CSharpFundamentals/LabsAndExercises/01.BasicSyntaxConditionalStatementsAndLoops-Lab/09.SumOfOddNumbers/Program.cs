using System.Security.Cryptography;

namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int n = int.Parse(Console.ReadLine());

            int sumOfOddNumbers = 0; 

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i + i - 1);
                sumOfOddNumbers += i + i - 1;
            }

            Console.WriteLine("Sum: {0}", sumOfOddNumbers);
        }
    }
}