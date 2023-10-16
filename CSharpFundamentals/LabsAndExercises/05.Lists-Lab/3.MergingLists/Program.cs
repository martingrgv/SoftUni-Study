namespace _3.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> mergedList = new List<int>();

            List<int> longestNumList = numbers1.Count > numbers2.Count ? numbers1 : numbers2;

            for (int i = 0; i < longestNumList.Count; i++)
            {
                if (i > numbers2.Count - 1)
                {
                    mergedList.Add(numbers1[i]);
                }
                else if (i > numbers1.Count - 1)
                {
                    mergedList.Add(numbers2[i]);
                }
                else
                {
                    mergedList.Add(numbers1[i]);
                    mergedList.Add(numbers2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedList));
        }
    }
}