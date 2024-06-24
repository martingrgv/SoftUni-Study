namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Console.WriteLine(SumNumbers(numbers));
        }

        private static int SumNumbers(int[] numbers, int index = 0)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + SumNumbers(numbers, ++index);
        }
    }
}
