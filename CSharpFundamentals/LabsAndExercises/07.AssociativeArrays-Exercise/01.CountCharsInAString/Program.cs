namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                            .Split()
                            .ToArray();

            var occurrencesDict = new Dictionary<char, int>();

            AddTextToDict(occurrencesDict, words);
            PrintDict(occurrencesDict);
        }

        static void AddTextToDict(Dictionary<char, int> dict, string[] words)
        {
            foreach (var word in words)
            {
                foreach (var ch in word)
                {
                    if (dict.ContainsKey(ch))
                    {
                        dict[ch]++;
                    }
                    else
                    {
                        dict.Add(ch, 1);
                    }
                }
            }
        }

        static void PrintDict(Dictionary<char, int> dict)
        {
            foreach (var ch in dict)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}