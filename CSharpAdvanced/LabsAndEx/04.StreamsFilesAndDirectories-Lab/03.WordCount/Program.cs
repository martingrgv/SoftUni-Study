using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> words = GetWords(wordsFilePath);

            string text = GetText(textFilePath);

            // Search text
            foreach (var word in words)
            {
                string pattern = $@"\b(?i){word.Key}\b";
                Regex regex = new Regex(pattern);
                
                foreach (Match match in regex.Matches(text))
                {
                    words[word.Key]++;
                }
            }

            WriteWords(words, outputFilePath);
        }

        private static Dictionary<string, int> GetWords(string wordsFilePath)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(wordsFilePath)) // Read words
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] lineWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < lineWords.Length; i++)
                    {
                        string word = lineWords[i];

                        if (!words.ContainsKey(word))
                            words.Add(word, 0);
                    }
                }
            }

            return words;
        }

        private static string GetText(string textFilePath)
        {
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                return reader.ReadToEnd();
            }
        }

        private static void WriteWords(Dictionary<string, int> words, string outputFilePath)
        {
            Dictionary<string, int> orderedWords = words.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in orderedWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
