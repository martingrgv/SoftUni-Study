using System.Linq.Expressions;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            for (int i = 1; i <= endValue; i++)
            {
                if (isSumDivisible(i) && holdsOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool isSumDivisible(int num)
        {
            int sum = 0;
            
            while (num > 0)
            {
                sum = sum + num % 10;
                num = num / 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool holdsOddDigit(int num)
        {
            while (num > 0)
            {
                if ((num % 10) % 2 != 0)
                {
                    return true;
                }
                num = num / 10;
            }

            return false;
        }
    }
}