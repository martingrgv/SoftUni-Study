amespace _2.GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Order first + last, first + 1 + last - 1, first + 2 + last - 2, … first + n, last - n.
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0, j = numbers.Count - 1; i < numbers.Count / 2; i++, j--)
            {
                result.Add(numbers[i] + numbers[j]);
            }

            if (numbers.Count % 2 != 0)
            {
                result.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}