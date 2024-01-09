using System.Text;
using System.Text.RegularExpressions;

namespace _02.EncryptingPassword;
class Program
{
    static void Main(string[] args)
    {
        string pattern = @"(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1";
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Match match = Regex.Match(input, pattern);

            if (Regex.IsMatch(input, pattern))
            {
                string encryptedPassword = GetEncryptString(match);
                System.Console.WriteLine("Password: " + encryptedPassword);
            }
            else
            {
                System.Console.WriteLine("Try another password!");
            }
        }
    }

    static string GetEncryptString(Match match)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 2; i <= 5; i++)
        {
            sb.Append(match.Groups[i].Value);
        }

        return sb.ToString();
    }
}
