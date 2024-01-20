namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> orderedList = list.OrderByDescending(num => num).ToList();

            if (orderedList.Count < 3)
            {
                Console.WriteLine(string.Join(' ', orderedList));
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                Console.Write(orderedList[i] + " ");
            }
        }
    }
}
