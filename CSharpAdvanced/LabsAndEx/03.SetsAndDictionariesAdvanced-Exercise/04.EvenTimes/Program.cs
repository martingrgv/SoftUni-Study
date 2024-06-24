namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNum))
                {
                    numbers.Add(currentNum, 0);
                }

                numbers[currentNum]++;
            }

            foreach (var number in numbers)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}
