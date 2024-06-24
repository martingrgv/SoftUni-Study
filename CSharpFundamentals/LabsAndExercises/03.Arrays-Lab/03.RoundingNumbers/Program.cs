namespace _03.RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] numbers = Console.ReadLine()
                                     .Split(" ")
                                     .Select(float.Parse)
                                     .ToArray();
            int[] roundedNumbers = new int[numbers.Length];

            for (int i = 0; i < roundedNumbers.Length; i++)
            {
                roundedNumbers[i] = (int) Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine(numbers[i] + " => " + roundedNumbers[i]);
            }
        }
    }
}