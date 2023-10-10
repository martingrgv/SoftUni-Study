namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            text = GetRepeatedString(text, n);

            Console.WriteLine(text);
        }

        static string GetRepeatedString(string s, int n)
        {
            string result = String.Empty;
            for (int i = 0; i < n; i++)
            {
                result += s;
            }

            return result;
        }
    }
}