namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                usernames.Add(Console.ReadLine());

            Console.WriteLine(String.Join("\n", usernames));
        }
    }
}
