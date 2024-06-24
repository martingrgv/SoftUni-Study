namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int set1Size = size[0];
            int set2Size = size[1];

            for (int i = 0; i < set1Size; i++)
                set1.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < set2Size; i++)
                set2.Add(int.Parse(Console.ReadLine()));

            set1.IntersectWith(set2);

            Console.WriteLine(String.Join(' ', set1));
        }
    }
}
