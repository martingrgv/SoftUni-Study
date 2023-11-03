namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            AddToDict(dict);
            PrintDict(dict);
        }

        static void AddToDict(Dictionary<string, List<string>> dict)
        {
            int wordsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < wordsCount; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, new());
                }

                if (dict.ContainsKey(word))
                {
                    dict[word].Add(synonym);
                }
            }
        }

        static void PrintDict(Dictionary<string, List<string>> dict)
        {
            foreach (KeyValuePair<string, List<string>> word in dict)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}