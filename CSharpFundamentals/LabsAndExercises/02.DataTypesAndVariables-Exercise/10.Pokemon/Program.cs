namespace _10.Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int currentPower = power; // N
            int distance = int.Parse(Console.ReadLine()); // M
            int exhaustionFactor = int.Parse(Console.ReadLine()); // Y
            int targetsPoked = 0;

            while (currentPower >= distance)
            {
                currentPower -= distance;
                targetsPoked++;

                if (power / 2 == currentPower && exhaustionFactor != 0)
                {
                    currentPower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPower);
            Console.WriteLine(targetsPoked);
        }
    }
}