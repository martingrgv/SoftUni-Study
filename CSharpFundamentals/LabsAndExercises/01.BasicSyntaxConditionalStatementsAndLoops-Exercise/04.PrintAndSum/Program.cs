using System.Diagnostics.Tracing;

namespace _04.PrintAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = firstNum; i <= secondNum; i++)
            {
                Console.Write("{0} ", i);
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}