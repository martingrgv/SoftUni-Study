namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentElements = Console.ReadLine().Split();

                for (int j = 0; j < currentElements.Length; j++)
                {
                    elements.Add(currentElements[j]);
                }
            }

            Console.WriteLine(String.Join(' ', elements));
        }
    }
}
