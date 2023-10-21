namespace _02.TheLift;

class Program
{
    static void Main(string[] args)
    {
        // Wagon capacity = 4
        int queue = int.Parse(Console.ReadLine());
        int[] lifts = Console.ReadLine()
                      .Split(" ")
                      .Select(int.Parse)
                      .ToArray();

        bool hasEmptySpaces = true;

        for (int i = 0; i < lifts.Length; i++)
        {
            while (lifts[i] < 4)
            {
                if (queue > 0)
                {
                    lifts[i]++;
                    queue--;
                }
                else
                {
                    break;
                }
            }

            if (lifts[i] < 4)
            {
                hasEmptySpaces = true;
            }
            else
            {
                hasEmptySpaces = false;
            }
        }

        if (queue <= 0 && hasEmptySpaces)
        {
            System.Console.WriteLine("The lift has empty spots!");
            System.Console.WriteLine(String.Join(" ", lifts));
        }
        else if (queue > 0 && !hasEmptySpaces)
        {
            System.Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
            System.Console.WriteLine(String.Join(" ", lifts));
        }
        else if (queue <= 0 && !hasEmptySpaces)
        {
            System.Console.WriteLine(String.Join(" ", lifts));
        }
    }
}
