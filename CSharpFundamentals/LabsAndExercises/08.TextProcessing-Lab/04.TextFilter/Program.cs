namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> forbiddenWords = Console.ReadLine().Split(", ").ToList();
            string text = Console.ReadLine();

            if (forbiddenWords.Any(text.Contains))
            {
                forbiddenWords.ForEach(w => text = text.Replace(w, Encrypt(w)));
            }

            Console.WriteLine(text);
        }

        static string Encrypt(string word)
        {
            string hidden = string.Empty;

            foreach (char ch in word)
            {
                hidden += "*";
            }

            return hidden;
        }
    }
}