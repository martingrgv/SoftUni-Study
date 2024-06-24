namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>(); // Color|Type|Count

            // Read clothes from wardrobe
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] clothes = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string[] items = clothes[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                string color = clothes[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in items)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            // Search wardrobe
            string[] clothArgs = Console.ReadLine().Split();
            string searchColor = clothArgs[0];
            string clothing = clothArgs[1];

            foreach (var currentColor in wardrobe)
            {
                Console.WriteLine($"{currentColor.Key} clothes:"); // color

                foreach (var currentCloth in currentColor.Value)
                {
                    Console.Write($"* {currentCloth.Key} - {currentCloth.Value}"); // item - count

                    if (currentCloth.Key == clothing && currentColor.Key == searchColor)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
