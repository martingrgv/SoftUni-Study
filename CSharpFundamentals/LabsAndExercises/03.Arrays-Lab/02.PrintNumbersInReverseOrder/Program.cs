namespace _02.PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            // Read numbers
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Print array reversed
            for (int i = numbers.Length; i > 0; i--)
            {
                Console.Write(numbers[i - 1] + " ");
            }
        }
    }
}