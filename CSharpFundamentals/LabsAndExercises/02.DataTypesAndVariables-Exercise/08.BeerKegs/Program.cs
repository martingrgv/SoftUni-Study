namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kegs = int.Parse(Console.ReadLine());

            string biggestKegName = String.Empty;
            double biggestKegArea = 0;

            for (int i = 0; i < kegs; i++)
            {
                string currentKegName = String.Empty;
                double currentKegArea = 0;

                // Get keg info
                currentKegName = Console.ReadLine();

                double radius = double.Parse(Console.ReadLine());
                long height = long.Parse(Console.ReadLine());

                currentKegArea = Math.PI * Math.Pow(radius, 2) * height;

                // Find biggest keg
                if (biggestKegArea < currentKegArea)
                {
                    biggestKegName = currentKegName;
                    biggestKegArea = currentKegArea;
                }
            }
            Console.WriteLine(biggestKegName);
        }
    }
}