using System.Runtime.InteropServices.JavaScript;

namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTriangle(n);
        }

        static void CountUp(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }  
        }

        static void CountDown(int n)
        {
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintTriangle(int n)
        {
            CountUp(n);
            CountDown(n);
        }
    }
}