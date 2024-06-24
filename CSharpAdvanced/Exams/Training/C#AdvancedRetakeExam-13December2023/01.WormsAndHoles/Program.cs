namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new Stack<int>(Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray());

            Queue<int> holes = new Queue<int>(Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray());

            int matches = 0;
            int wormsCount = worms.Count;

            while (worms.Count > 0 && holes.Count > 0)
            {
                int currentWorm = worms.Peek();
                int currentHole = holes.Peek();

                if (currentWorm == currentHole)
                {
                    matches++;

                    worms.Pop();
                    holes.Dequeue();

                    continue;
                }

                worms.Push(worms.Pop() - 3);
                holes.Dequeue();

                if (worms.Peek() < 1)
                {
                    worms.Pop();
                }
            }

            if (matches > 0)
            {
                Console.WriteLine($"Matches: {matches}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (worms.Count == 0 && matches == wormsCount)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (worms.Count == 0)
            {
                Console.WriteLine("Worms left: none");
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
        }
    }
}
