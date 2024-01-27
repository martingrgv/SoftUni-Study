namespace _04.FindEvenOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

            int startRange = range[0];
            int endRange = range[1];

            List<int> numbers = new List<int>();

            for (int i = startRange; i <= endRange; i++) // Populating list with all numbers
            {
                numbers.Add(i);
            }

            string type = Console.ReadLine();

            Predicate<int> predicate;

            if (type == "even")
            {
                predicate = n => n % 2 == 0;
            }
            else
            {
                predicate = n => n % 2 != 0;
            }

            var filteredNumbers = numbers.Where(n => predicate(n));

            Console.WriteLine(string.Join(' ', filteredNumbers));
        }
    }
}
