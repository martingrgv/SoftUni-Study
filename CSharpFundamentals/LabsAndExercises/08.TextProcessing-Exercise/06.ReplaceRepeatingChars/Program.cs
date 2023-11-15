using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string word = RemoveRepeatingChars(input);

            Console.WriteLine(word);
        }

        static string RemoveRepeatingChars(string word)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(word[0]);

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] != word[i - 1])
                {
                    sb.Append(word[i]);
                }
            }

            return sb.ToString();
        }
    }
}