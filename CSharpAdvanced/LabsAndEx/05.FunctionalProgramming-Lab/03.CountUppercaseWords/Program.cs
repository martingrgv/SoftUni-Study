namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUppercase = w => char.IsUpper(w[0]);

            string[] text = Console.ReadLine()
                          .Split(" ",
                          StringSplitOptions.RemoveEmptyEntries)
                          .Where(w => isUppercase(w))
                          .ToArray();

            Console.WriteLine(string.Join('\n', text));
        }
    }
}
