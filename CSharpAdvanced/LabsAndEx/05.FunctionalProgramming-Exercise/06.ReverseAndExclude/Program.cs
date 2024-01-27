namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            int divisibleNum = int.Parse(Console.ReadLine());

            Predicate<int> predicate = n => n % divisibleNum == 0;

            numbers.RemoveAll(predicate);
            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
