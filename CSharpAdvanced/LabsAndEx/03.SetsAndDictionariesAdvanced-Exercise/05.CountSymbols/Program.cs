namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            string str = Console.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                if (!chars.ContainsKey(ch))
                {
                    chars.Add(ch, 0);
                }

                chars[ch]++;
            }

            foreach (var ch in chars)
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
        }
    }
}
