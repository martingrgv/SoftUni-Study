using System.Text.RegularExpressions;

namespace _02.EmojiDetector;
class Program
{
    static int emojiesCount = 0;

    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        int coolThreshold = GetCoolThreshold(text);
        List<string> coolEmojies = GetCoolEmojies(text, coolThreshold);

        System.Console.WriteLine($"Cool threshold: {coolThreshold}");
        System.Console.WriteLine($"{emojiesCount} emojis found in the text. The cool ones are:");
        System.Console.WriteLine(string.Join("\n", coolEmojies));
    }

    private static int GetCoolThreshold(string text)
    {
        string pattern = @"\d";
        MatchCollection matches = Regex.Matches(text, pattern);

        int sum = int.Parse(matches[0].Value);
        
        for (int i = 1; i < matches.Count; i++)
        {
            sum *= int.Parse(matches[i].Value);
        }

        return sum;
    }

    private static List<string> GetCoolEmojies(string text, int coolThreshold)
    {
        List<string> emojis = GetEmojiNames(text);
        List<string> coolEmojies = new();

        foreach (string emoji in emojis)
        {
            if (IsEmojiCool(emoji, coolThreshold))
                coolEmojies.Add(emoji);
        }

        return coolEmojies;
    }

    private static List<string> GetEmojiNames(string text)
    {
        List<string> emojiNames = new();

        string pattern = @"(::|\*\*)(?<EmojiName>[A-Z][a-z]{2,})\1";
        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            emojiNames.Add(match.Value);
        }

        emojiesCount = emojiNames.Count;
        return emojiNames;
    }

    private static string SliceEmojiName(string emojiName)
    {
        string pattern = @"(::|\*\*)(?<EmojiName>[A-Z][a-z]{2,})\1";
        Match match = Regex.Match(emojiName, pattern);

        return match.Groups["EmojiName"].Value;
    }

    private static bool IsEmojiCool(string emoji, int coolThreshold)
    {
        string emojiName = SliceEmojiName(emoji);
        char[] emojiNameArr = emojiName.ToCharArray();
        int emojiValueSum = 0;

        foreach (char ch in emojiNameArr)
        {
            emojiValueSum += ch;
        }

        if (emojiValueSum < coolThreshold)
            return false;

        return true;
    }
}
