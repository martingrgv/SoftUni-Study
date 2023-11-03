namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                            .Split()
                            .Select(double.Parse)
                            .ToArray();

            SortedDictionary<double, int> dict = new SortedDictionary<double, int>();

            AddToDict(dict, numbers);
            PrintDict(dict);
        }

        static void AddToDict(SortedDictionary<double, int> dict, double[] numbers)
        {
            foreach (double number in numbers)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number]++;
                }
                else
                {
                    dict.Add(number, 1);
                }
            }
        }

        static void PrintDict(SortedDictionary<double, int> dict)
        {
            foreach (var num in dict)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}