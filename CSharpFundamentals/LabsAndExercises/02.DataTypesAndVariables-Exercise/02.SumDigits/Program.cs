namespace _02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            // Input
            int number = int.Parse(Console.ReadLine());

            // Logic
            int currentNumber = number;
            while (currentNumber > 0)
            {
                sum += currentNumber % 10;
                currentNumber /= 10;
            }
            // Output
            Console.WriteLine(sum);
        }
    }
}