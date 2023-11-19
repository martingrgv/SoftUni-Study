using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);
            var matchedPhones = matches.Cast<Match>().Select(m => m.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}