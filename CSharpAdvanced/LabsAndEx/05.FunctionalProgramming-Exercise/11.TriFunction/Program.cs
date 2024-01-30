namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                                 .Split(' ',
                                 StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            // Logic
            Func<string, int, bool> predicate = (name, n) =>
            {
                int sum = 0;

                foreach (char ch in name)
                    sum += ch;

                if (sum >= n)
                    return true;
                else
                    return false;
            };

            Func<List<string>, int, Func<string, int, bool>, string> GetName = (names, n, predicate) =>
            {
                foreach (var name in names)
                {
                    if (predicate(name, n))
                        return name;
                }

                return null;
            };

            string firstFoundName = GetName(names, n, predicate);

            // Output
            if (firstFoundName != null)
                Console.WriteLine(firstFoundName);
        }
    }
}
