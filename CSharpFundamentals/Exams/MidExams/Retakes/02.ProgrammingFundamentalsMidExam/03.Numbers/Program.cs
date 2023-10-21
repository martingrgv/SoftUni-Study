namespace _03.Numbers;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToList();

        numbers.Sort();
        numbers.Reverse();

        double average = 0;

        // Find average
        for (int i = 0; i < numbers.Count; i++)
        {
            average += numbers[i];
        }

        average = average / numbers.Count;

        int printCount = 0;
        bool foundAverage = false;

        // Find greater
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > average && printCount < 5)
            {
                foundAverage = true;
                printCount++;
                
                Console.Write($"{numbers[i]} ");
            }
            else
            {
                if (i == numbers.Count - 1 && !foundAverage)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
        }
    }
}
