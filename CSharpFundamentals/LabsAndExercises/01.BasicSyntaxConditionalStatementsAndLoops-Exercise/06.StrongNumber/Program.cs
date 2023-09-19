namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int n = inputNum; 
            int sum = 0;

            for (int i = 0; i < inputNum.ToString().Length; i++)
            {
                int lastDigit = n % 10;
                int factorial = 1;

                // Get factorial
                for (int j = lastDigit; j > 0; j--)
                {
                    factorial = factorial * j;
                }
                sum += factorial;

                n = n / 10;
            }

            if (inputNum == sum)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}