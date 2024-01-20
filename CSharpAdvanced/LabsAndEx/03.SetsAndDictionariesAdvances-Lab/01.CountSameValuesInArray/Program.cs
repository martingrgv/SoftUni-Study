namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            // Populate dict
            for (int i = 0; i < numbers.Length; i++) // Loop through array
            {
                double number = numbers[i];

                if (occurrences.ContainsKey(number))
                {
                    occurrences[number]++;
                }
                else
                {
                    occurrences.Add(number, 1);
                }
            }

            // Print 
            foreach (var number in occurrences)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
