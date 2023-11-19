using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"\b(?<FirstName>[A-Z][a-z]+) (?<LastName>[A-Z][a-z]+)\b";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }
        }
    }
}