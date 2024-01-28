namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Func and Predicates

            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                           .Split(' ',
                           StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();
            List<int> numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            Func<int, bool> predicate = n =>
            {
                foreach (int divider in dividers)
                {
                    if (n % divider != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            var result = numbers.Where(n => predicate(n));
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
