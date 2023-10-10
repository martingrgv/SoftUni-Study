namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = GetMultipleOfEvenAndOdds(n);
            Console.WriteLine(sum);
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            number = Math.Abs(number);
            int sumOfEven = GetSumOfEvenDigits(number);
            int sumOfOdd = GetSumOfOddDigits(number);

            return sumOfEven * sumOfOdd;
        }

        static int GetSumOfEvenDigits(int n)
        {
            int[] numbers = GetEachNumber(n);
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }
            }

            return sum;
        }
        
        static int GetSumOfOddDigits(int n)
        {
            int[] numbers = GetEachNumber(n);
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    sum += numbers[i];
                }
            }

            return sum;
        }

        static int[] GetEachNumber(double n) => n.ToString().Select(ch => Convert.ToInt32(ch) - 48).ToArray();
    }
}