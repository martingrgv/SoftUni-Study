using System.Text.RegularExpressions;

namespace _02.MirrorWords;
class Program
{
    static void Main(string[] args)
    {
        string? text = Console.ReadLine();

        Dictionary<string, string> matches = GetWords(text);
        Dictionary<string, string> mirrors =  GetMirrors(matches);

        // Print output
        if (matches.Count > 0)
            System.Console.WriteLine(matches.Count + " word pairs found!");
        else
            System.Console.WriteLine("No word pairs found!");
        
        if (mirrors.Count > 0)
        {
            System.Console.WriteLine("The mirror words are:");
            System.Console.WriteLine(string.Join(", ", mirrors.Select(m => $"{m.Key} <=> {m.Value}")));
        }
        else
            System.Console.WriteLine("No mirror words!");
    }

    private static Dictionary<string, string> GetWords(string text)
    {
        Dictionary<string, string> words = new();
        
        string pattern = @"(#|@)(?<First>[A-Za-z]{3,})\1\1(?<Second>[A-Za-z]{3,})\1";
        MatchCollection matches = Regex.Matches(text, pattern);
        
        foreach (Match match in matches)
        {
            words.Add(match.Groups["First"].Value, match.Groups["Second"].Value);
        }

        return words;
    }

    private static Dictionary<string, string> GetMirrors(Dictionary<string, string> matches)
    {
        Dictionary<string, string> mirrors = new();

        foreach (var match in matches)
        {
            if (match.Key == Reverse(match.Value))
            {
                mirrors.Add(match.Key, match.Value);
            }
        }

        return mirrors;
    }

    private static string Reverse(string s)
    {
        char[] charArr = s.ToCharArray();
        Array.Reverse(charArr);

        return new string(charArr);
    }
}