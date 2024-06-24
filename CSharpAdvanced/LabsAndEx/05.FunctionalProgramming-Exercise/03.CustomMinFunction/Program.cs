namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                             .Split(' ',
                             StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            int smallestNum = int.MaxValue;

            Func<int, int> NumIdentifier = n => n < smallestNum ? n : smallestNum;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                smallestNum = NumIdentifier(number);
            }

            Console.WriteLine(smallestNum);

        }
    }
}
