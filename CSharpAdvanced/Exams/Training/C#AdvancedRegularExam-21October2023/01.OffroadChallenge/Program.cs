namespace _01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuel = new Stack<int>(Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse)
                                                    .ToArray());

            Queue<int> consumption = new Queue<int>(Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse)
                                                    .ToArray());

            Queue<int> neededFuel = new Queue<int>(Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse)
                                                    .ToArray());

            int altitudesCount = initialFuel.Count;
            int reachedAltitudes = 0;

            while (initialFuel.Count > 0)
            {
                if (initialFuel.Pop() - consumption.Dequeue() >= neededFuel.Dequeue())
                {
                    reachedAltitudes++;
                    Console.WriteLine($"John has reached: Altitude {reachedAltitudes}");
                    continue;
                }

                Console.WriteLine($"John did not reach: Altitude {reachedAltitudes + 1}");
                break;
            }

            if (reachedAltitudes > 0)
            {
                if (reachedAltitudes == altitudesCount)
                {
                    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                    return;
                }

                Console.WriteLine($"John failed to reach the top.");
                Console.Write("Reached altitudes: ");

                int count;
                for (count = 1; count <= reachedAltitudes - 1; count++)
                {
                    Console.Write($"Altitude {count}, ");
                }

                Console.WriteLine($"Altitude {count}");
            }
            else
            {
                Console.WriteLine("John failed to reach the top.\nJohn didn't reach any altitude.");
            }
        }
    }
}
