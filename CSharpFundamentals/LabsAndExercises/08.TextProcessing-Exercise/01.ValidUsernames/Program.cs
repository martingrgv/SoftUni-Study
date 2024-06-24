namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            string[] validUsernames = GetValidUsernames(usernames);

            Console.WriteLine(string.Join("\n", validUsernames));
        }

        static string[] GetValidUsernames(string[] usernames)
        {
            string[] validLenghtUsernames = usernames.Where(u => u.Length >= 3 && u.Length <= 16).ToArray();
            return validLenghtUsernames.Where(u => u.All(ch => char.IsLetterOrDigit(ch) || ch == '-' || ch == '_')).ToArray();
        }
    }
}