namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                             .Split()
                             .Where(n => n.Length <= length)
                             .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
