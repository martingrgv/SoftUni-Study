namespace _09.CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string output = String.Empty;

            for (int i = 0; i < 3; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                output += currentChar;
            }

            Console.WriteLine(output);
        }
    }
}