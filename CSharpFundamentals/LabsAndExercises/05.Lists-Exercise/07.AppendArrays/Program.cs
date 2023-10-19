namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arrList = new List<int>();
            string[] arrOfArrays = Console.ReadLine()
                                       .Split('|', StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

            for (int i = arrOfArrays.Length - 1; i >= 0; i--)
            {
                int[] currentArr = arrOfArrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                foreach (int number in currentArr)
                {
                    arrList.Add(number);
                }
            }

            Console.WriteLine(string.Join(' ', arrList));
        }
    }
}