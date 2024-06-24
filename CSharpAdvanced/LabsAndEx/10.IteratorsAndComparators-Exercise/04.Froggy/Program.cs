namespace _04.Froggy;
class Program
{
    static void Main(string[] args)
    {
        int[] stones = GetStones();
        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }

    private static int[] GetStones() => Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
}