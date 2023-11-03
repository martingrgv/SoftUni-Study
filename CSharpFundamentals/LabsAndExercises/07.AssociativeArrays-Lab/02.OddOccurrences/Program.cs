namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                             .Split()
                             .ToArray();
            Dictionary<string, int> occurrianceCount = new Dictionary<string, int>();

            AddToDict(occurrianceCount, words);
            PrintDict(occurrianceCount);
        }

        static void AddToDict(Dictionary<string, int> dict, string[] words)
        {
            foreach (string word in words)
            {
                string wordToLower = word.ToLower();
                if (dict.ContainsKey(wordToLower))
                {
                    dict[wordToLower]++;
                }
                else
                {
                    dict.Add(wordToLower, 1);
                }
            }
        }

        static void PrintDict(Dictionary<string, int> dict)
        {
            foreach (var word in dict)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}