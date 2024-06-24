namespace _07.CustomComparator;
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

        Array.Sort(numbers, new CustomComparator());

        Console.WriteLine(string.Join(' ', numbers));
    }
}

