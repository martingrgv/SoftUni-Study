namespace _04.GenericSwapMethodInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < lines; i++)
                list.Add(int.Parse(Console.ReadLine()));

            int[] indexes = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            GenericSwap(list, indexes[0], indexes[1]);

            foreach (var item in list)
                Console.WriteLine($"{item.GetType()}: {item}");
        }

        private static void GenericSwap<T>(List<T> items, int firstIndex, int secondIndex)
        {
            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }
    }
}
