namespace _01.SortEvennbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] evenNumbers = Console.ReadLine()
                                .Split(", ",
                                StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .Where(n => n % 2 == 0)
                                .OrderBy(n => n)
                                .ToArray();

            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
